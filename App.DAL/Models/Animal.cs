using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.DAL.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
		[StringLength(10, MinimumLength = 3)]
		[RegularExpression("^[^0-9]+$")]
		public string? Name { get; set; }
        [Required]
		[Range(0, 30)]
		public int Age { get; set; }
        [Required (ErrorMessage ="Please Enter a Picture")]
		[RegularExpression((".*\\.(jpg|png|JPG|PNG)$"), ErrorMessage = "Please enter a png or jpg picture ")]
		public string? PictureName { get; set; }
        [Required]
		[StringLength(300, MinimumLength = 3)]
		public string? Description { get; set; }
		[Required(ErrorMessage = "Please Select a category")]
		public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; } 

    }
}
