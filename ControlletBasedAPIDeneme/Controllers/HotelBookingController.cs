using ControlletBasedAPIDeneme.Data;
using ControlletBasedAPIDeneme.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlletBasedAPIDeneme.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        ApiContext _context;
        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult Create(HotelBooking hotelBooking)
        {
            if (hotelBooking.Id == 0)
                _context.Bookings.Add(hotelBooking);
            else
            {
                var bookingInDb = _context.Bookings.Find(hotelBooking.Id);
                if (bookingInDb == null)
                    return new JsonResult(NotFound());
                bookingInDb = hotelBooking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(hotelBooking));
        }
        [HttpGet]
        public JsonResult Get(int id) {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(booking));
        }
        [HttpDelete]
        public JsonResult Delete(int id) {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
                return new JsonResult(NotFound());
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }
        [HttpGet]
        public JsonResult GetAll() {
            var bookings = _context.Bookings.ToList();
            return new JsonResult(Ok(bookings));
        }
    }
}
