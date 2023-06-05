using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
		[StringLength(10, MinimumLength = 3)]
		[RegularExpression("^[^0-9]+$")]
		public string? Name { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; } 
    }
}
