using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewProject.Data;
using NewProject.Models;

namespace NewProject.Controllers
{
    [ApiController]
    [Route("NewProject/Travel")]
    public class TravelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TravelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Travel = _context.Travel.ToList();
            return Ok(Travel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Travel = _context.Travel.Find(id);
            
            if (Travel == null)
            {
                return NotFound();
            }
            
            return Ok(Travel);
        }

        [HttpPost]
        public IActionResult CreateTravel([FromBody]Travel travel)
        {
            if (travel==null)
            {
                return NotFound();
            }

            _context.Travel.Add(travel);
            _context.SaveChanges();

            return Ok(travel);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTravel ([FromRoute] int id) {

            var TravelDel= _context.Travel.Find(id);

            if (TravelDel== null){
                return NotFound();
            }

            _context.Travel.Remove(TravelDel);
            _context.SaveChanges();

            return Ok();
        }
    }
}
