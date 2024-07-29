using Microsoft.AspNetCore.Mvc;
using TransportDepotAPI.Models;
using TransportDepotAPI.Services;

namespace TransportDepotAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("cars")]
        public IActionResult GetCarsByColor([FromQuery] string color)
        {
            try
            {
                var cars = _vehicleService.GetCarsByColor(color);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("buses")]
        public IActionResult GetBusesByColor([FromQuery] string color)
        {
            try
            {
                var buses = _vehicleService.GetBusesByColor(color);
                return Ok(buses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("boats")]
        public IActionResult GetBoatsByColor([FromQuery] string color)
        {
            try
            {
                var boats = _vehicleService.GetBoatsByColor(color);
                return Ok(boats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("cars/{id}/headlights")]
        public IActionResult ToggleHeadlights(int id)
        {
            try
            {
                CarModel carModel = _vehicleService.FlipHeadlights(id);

                if (carModel == null)
                    return NotFound($"No car with ID {id} found");

                return Ok(carModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("cars/{id}")]
        public IActionResult DeleteCar(int id)
        {
            try
            {
                bool result = _vehicleService.DeleteCar(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
