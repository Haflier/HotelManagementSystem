using api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class CustomerRoleDowngradeService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CustomerRoleDowngradeService> _logger;

    public CustomerRoleDowngradeService(IServiceProvider serviceProvider, ILogger<CustomerRoleDowngradeService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("CustomerRoleDowngradeService started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Get all users in "Customer" role
                var customers = await dbContext.Users
                    .Where(u => dbContext.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == dbContext.Roles.First(r => r.Name == "Customer").Id))
                    .ToListAsync();

                foreach (var customer in customers)
                {
                    // Get the user's active reservations
                    var activeReservations = await dbContext.Reservations
                        .Where(r => r.ApiUserId == customer.Id && r.CheckOutDate >= DateTime.UtcNow)
                        .ToListAsync();

                    // If no active/future reservations, downgrade role
                    if (!activeReservations.Any())
                    {
                        if (await userManager.IsInRoleAsync(customer, "Customer"))
                        {
                            await userManager.RemoveFromRoleAsync(customer, "Customer");

                            // Optionally, add back the "User" role if removed previously
                            if (!await userManager.IsInRoleAsync(customer, "User"))
                                await userManager.AddToRoleAsync(customer, "User");

                            _logger.LogInformation($"User {customer.Email} demoted to User role.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CustomerRoleDowngradeService.");
            }

            // Check every hour (adjust as needed)
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}