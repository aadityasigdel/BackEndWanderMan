using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewProject.Data;
using NewProject.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("NewProject/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hotels = _context.Hotel.ToList();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var hotel = _context.Hotel.Find(id);
            
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {
            if (hotel==null)
            {
                return NotFound();
            }

            _context.Hotel.Add(hotel);
            _context.SaveChanges();

            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id , [FromBody]Hotel hotel){

            var hotelData = _context.Hotel.Find(id);
            if (hotelData == null){
                return NotFound();
            }

            hotelData.Name = hotel.Name;
            hotelData.Price = hotel.Price;
            hotelData.Image = hotel.Image;
            hotelData.Description = hotel.Description;
            hotelData.Ratings = hotel.Ratings;
            hotelData.Cancelation = hotel.Cancelation;
            hotelData.Reservation = hotel.Reservation;

            _context.Hotel.Update(hotelData);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteHotel ([FromRoute] int id) {

            var hotelDelete = _context.Hotel.Find(id);

            if (hotelDelete == null){
                return NotFound();
            }

            _context.Hotel.Remove(hotelDelete);
            _context.SaveChanges();

            return Ok();
        }
    }

}
