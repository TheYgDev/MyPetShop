using App.BLL.Services.Contracts;
using App.DAL.DataContext;
using App.DAL.Models;
using App.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services.EnttiyServices
{
	public class CommentsService : ICommentsService
	{
		private readonly CommentsRepository _repo;


		public CommentsService(DbPetsContext repo)
		{
			_repo = new CommentsRepository(repo);
		}

		public void AddAsync(Comment entity, int animalId)
		{
			if (entity == null || entity.Text == string.Empty)
				return;
			entity.AnimalId = animalId;
			 _repo.AddAsync(entity);			
		}

		public void AddRangeAsync(IEnumerable<Comment> entities, int animalId)
		{
			throw new NotImplementedException();
		}

		public  IEnumerable<Comment> GetAnimalComments(int animalId)
		{
			return  _repo.Find(c => c.AnimalId == animalId);
			
		}
	}
}