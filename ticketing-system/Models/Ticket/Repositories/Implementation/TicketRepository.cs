﻿using ticketing_system.DTO;
using ticketing_system.Models.Ticket.Repository.Abstraction;

namespace ticketing_system.Models.Ticket.Repository.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public Task<Ticket> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}