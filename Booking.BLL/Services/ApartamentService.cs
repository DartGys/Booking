using AutoMapper;
using Booking.BLL.Interfaces;
using Booking.BLL.Models;
using Booking.DAL.Data;
using Booking.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.BLL.Services
{
    public class ApartamentService : IApartamentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApartamentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApartamentModel>> GetAllAsync()
        {
            var entities = await _context.Apartaments.ToListAsync();

            var models = _mapper.Map<IEnumerable<ApartamentModel>>(entities);

            return models;
        }

        public async Task<ApartamentModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Apartaments.FindAsync(id);

            var model = _mapper.Map<ApartamentModel>(entity);
            
            return model;
        }

        public async Task<ApartamentModel> AddAsync(ApartamentModel model)
        {
            var entity = _mapper.Map<Apartament>(model);

            await _context.Apartaments.AddAsync(entity);
            await _context.SaveChangesAsync();

            var apartament = _mapper.Map<ApartamentModel>(entity);

            return apartament;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var entity = new Apartament { Id = Id };

            _context.Apartaments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ApartamentModel> UpdateAsync(ApartamentModel model)
        {
            await _context.Apartaments
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(p => p
                .SetProperty(e => e.Location, model.Location)
                .SetProperty(e => e.Price, model.Price)
                .SetProperty(e => e.Rooms, model.Rooms)
                .SetProperty(e => e.Owner, model.Owner));

            return model;
        }
    }
}
