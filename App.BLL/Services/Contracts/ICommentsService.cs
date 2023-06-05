using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services.Contracts
{
    public interface ICommentsService
    {
		IEnumerable<Comment> GetAnimalComments(int animalId);
		void AddAsync(Comment entity,int animalId);
		void AddRangeAsync(IEnumerable<Comment> entities,int animalId);


	}
}
