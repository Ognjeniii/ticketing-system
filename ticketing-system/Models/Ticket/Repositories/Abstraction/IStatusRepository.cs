﻿namespace ticketing_system.Models.Ticket.Repositories.Abstraction
{
    public interface IStatusRepository
    {
        Task Create(Status status);
        Task<Status> GetByIdAsync(int id);
        Task<List<Status>> GetAll();
    }
}