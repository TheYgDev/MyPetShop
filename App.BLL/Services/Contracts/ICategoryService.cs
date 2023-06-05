using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services.Contracts
{
    public interface ICategoryService
    {
         IEnumerable<Category> Get();
         Category GetById(int id);

    }
}
