using App.BLL.Services.Contracts;
using App.DAL.DataContext;
using App.DAL.Models;
using App.DAL.Repositories;
using App.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services.EnttiyServices
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _repo;

        public CategoryService(DbPetsContext repository)
        {
            _repo = new CategoryRepository(repository);
        }
        public IEnumerable<Category> Get() => _repo.GetAll().ToList();

        public Category GetById(int id) => _repo.GetById(id);
    }
}
