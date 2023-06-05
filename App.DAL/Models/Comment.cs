using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
        [Required]
		[StringLength(200, MinimumLength = 3)]
		public string? Text { get; set; }
    }
}
