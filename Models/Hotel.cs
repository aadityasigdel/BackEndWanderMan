using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewProject.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name{set; get;} = String.Empty;
        public int Price {set; get;}

        public int Ratings {set; get;}

        public string Description  {set; get;} = String.Empty;
        public List <string> Image {set; get;} = new List<string>();

        public bool Cancelation {set; get;}

        public bool Reservation {set; get;}


    }
}