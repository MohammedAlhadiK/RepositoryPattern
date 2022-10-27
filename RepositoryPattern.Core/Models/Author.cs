using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Models
{
    [Table("Authors", Schema = "Oth")]

    public class Author
    {
        public int ID { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; } = string.Empty;
    }
}
