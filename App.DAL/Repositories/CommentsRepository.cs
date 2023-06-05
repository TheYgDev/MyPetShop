using App.DAL.DataContext;
using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
	public class CommentsRepository : GenericRepository<Comment>, ICommentsRepository
	{
		public CommentsRepository(DbPetsContext context) : base(context)
		{
		}
	}
}
