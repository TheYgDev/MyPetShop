using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Contracts
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        IEnumerable<Animal> OrderByDescending(IEnumerable<Animal> animals);
        IEnumerable<Animal> OrderBy(IEnumerable<Animal> animals);
        void Update(Animal entity);
    }
    public interface ICommentsRepository : IGenericRepository<Comment>
    {
    }
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
