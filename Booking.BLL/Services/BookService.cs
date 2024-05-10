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
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookModel>> GetAllAsync()
        {
            var entities = await _context.Books.ToListAsync();

            var models = _mapper.Map<IEnumerable<BookModel>>(entities);

            return models;
        }

        public async Task<BookModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.Books.FindAsync(id);

            var model = _mapper.Map<BookModel>(entity);

            return model;
        }

        public async Task<BookModel> AddAsync(BookModel model)
        {
            var entity = _mapper.Map<Book>(model);

            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();

            var book = _mapper.Map<BookModel>(entity);

            return book;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new Book { Id = id };

            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<BookModel> UpdateAsync(BookModel model)
        {
            await _context.Books
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(p => p
                .SetProperty(e => e.UserId, model.UserId)
                .SetProperty(e => e.ApartamentId, model.ApartamentId)
                .SetProperty(e => e.StartDate, model.StartDate)
                .SetProperty(e => e.EndDate, model.EndDate)
                .SetProperty(e => e.Price, model.Price));

            return model;
        }
    }
}
