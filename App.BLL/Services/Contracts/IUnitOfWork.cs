using App.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalService Animals { get; }
        ICategoryService Categories { get; }
        ICommentsService Comments { get; }
        Task<int> Complete();
    }
}
