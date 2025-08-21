using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using apiRepositories;
using AutoMapper;

namespace api.Repositories 
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderItemRepository(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int ConvertToDeterministicRandomNumber(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                // Hash input string
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Take first 8 bytes and convert to int (32-bit)
                int value = BitConverter.ToInt32(hash, 0);

                // Ensure it's positive
                return Math.Abs(value);
            }
        }
    }
}