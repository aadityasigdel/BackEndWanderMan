using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewProject.Models;

namespace NewProject.Models
{
    public class HotelBookings
    {
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int UserId { get; set; }
        public LoginC User { get; set; }

        public DateTime BookingDate { get; set; }

        public int Duration { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
