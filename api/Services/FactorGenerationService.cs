using api.Data;
using api.Models;

namespace api.Services
{
    public class FactorGenerationService : BackgroundService
    {
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<FactorGenerationService> _logger;

    public FactorGenerationService(IServiceProvider serviceProvider, ILogger<FactorGenerationService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("FactorGenerationService started.");
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var now = DateTime.UtcNow;

                    // Find ended reservations with no factor yet
                    var endedReservations = db.Reservations
                        .Where(r => r.CheckOutDate <= now)
                        .Where(r => !db.Factors.Any(f => f.ReservationId == r.Id))
                        .ToList();

                    foreach (var reservation in endedReservations)
                    {
                        // Get finalized orders for this reservation's user
                        var orders = db.Orders
                            .Where(o => o.ApiUserId == reservation.ApiUserId
                                     && o.CreatedAt >= reservation.CheckinDate
                                     && o.CreatedAt <= reservation.CheckOutDate
                                     && o.IsFinalized)
                            .ToList();

                        decimal ordersTotalPrice = db.Orders.Where(o => o.ApiUserId == reservation.ApiUserId)
                                                                        .Sum(o => o.TotalPrice);

                        // Final total = reservation + orders
                        decimal finalPrice = reservation.TotalPrice + ordersTotalPrice;

                        // Create Factor tied to Reservation
                        var factor = new Factor
                        {
                            ApiUserId = reservation.ApiUserId,
                            ReservationId = reservation.Id,
                            CreatedAt = now,
                            FinalPrice = finalPrice
                        };

                        db.Factors.Add(factor);
                     }

                    // Save once for all reservations
                    if (endedReservations.Any())
                    {
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating factor automatically.");
            }

            // Wait before next check (prevents infinite loop)
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
    }
}