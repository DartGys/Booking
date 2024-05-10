using AutoMapper;
using Booking.BLL.Interfaces;
using Booking.BLL.Models;
using Booking.DAL.Data;
using Booking.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var entities = await _context.Users.ToListAsync();

            var models = _mapper.Map<IEnumerable<UserModel>>(entities);

            return models;
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Users.FindAsync(id);

            var models = _mapper.Map<UserModel>(entity);

            return models;
        }

        public async Task<UserModel> AddAsync(UserModel model)
        {
            var entity = _mapper.Map<User>(model);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            var user = _mapper.Map<UserModel>(entity);

            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new User() { Id = id };

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> UpdateAsync(UserModel model)
        {
            await _context.Users
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(p => p
                .SetProperty(x => x.Name, model.Name)
                .SetProperty(x => x.Email, model.Email));

            return model;
        }
    }
}
