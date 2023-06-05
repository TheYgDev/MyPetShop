using App.DAL.DataContext;
using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(DbPetsContext context) : base(context)
        {
        }

        public IEnumerable<Animal> OrderByDescending(IEnumerable<Animal> animals)
        {
           return animals.OrderByDescending(d => d.Comments!.Count());
        }
        public IEnumerable<Animal> OrderBy(IEnumerable<Animal> animals)
        {
			return animals.OrderBy(d => d.Comments!.Count());
        }

        public async void Update(Animal entity)
        {
            var result = await _context.Animals
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (result != null)
                result = entity;
        }
    }
}
