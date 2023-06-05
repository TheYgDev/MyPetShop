using App.BLL.Services.Contracts;
using App.BLL.Services.EnttiyServices;
using App.DAL.DataContext;
using App.DAL.Repositories;
using App.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbPetsContext _context;
        public UnitOfWork(DbPetsContext context)
        {
            _context = context;
            Animals = new AnimalService(_context);
            Categories = new CategoryService(_context);
            Comments = new CommentsService(_context);
        }
        public ICategoryService Categories { get; private set; }
        public IAnimalService Animals { get; private set; }
        public ICommentsService Comments { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
