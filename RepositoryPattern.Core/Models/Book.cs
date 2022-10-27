using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Models
{
    [Table("Books",Schema ="bok")]
    public class Book
    {
        public int ID { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
