using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Models
{
    [Table("Travel")]
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        public string Name{set; get;} = String.Empty;
        public int Price {set; get;}

        public List <string> Image {set; get;} = new List<string>();

        public string Description  {set; get;} = String.Empty;

    }
}