using TransportDepotAPI.Models;

namespace TransportDepotAPI.Services
{
    public interface IVehicleService
    {
        IEnumerable<VehicleModel> GetCarsByColor(string color);
        IEnumerable<VehicleModel> GetBusesByColor(string color);
        IEnumerable<VehicleModel> GetBoatsByColor(string color);
        CarModel FlipHeadlights(int carId);
        bool DeleteCar(int carId);
    }
}
