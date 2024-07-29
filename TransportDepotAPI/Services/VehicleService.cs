using TransportDepotAPI.Models;

namespace TransportDepotAPI.Services
{
    public class VehicleService : IVehicleService //Temel Interface'den Türetilmesi
    {
        private readonly List<VehicleModel> _vehicles = new List<VehicleModel>
        {
            new CarModel { Id = 1, Color = "Red" },
            new CarModel { Id = 2, Color = "Blue" },
            new CarModel { Id = 3, Color = "Black" },
            new CarModel { Id = 4, Color = "White" },
            new BoatModel { Id = 5, Color = "Red" },
            new BoatModel { Id = 6, Color = "Blue" },
            new BoatModel { Id = 7, Color = "Black" },
            new BoatModel { Id = 8, Color = "White" },
            new BusModel { Id = 9, Color = "Red" },
            new BusModel { Id = 10, Color = "Blue" },
            new BusModel { Id = 11, Color = "Black" },
            new BusModel { Id = 12, Color = "White" }
        };

        public IEnumerable<VehicleModel> GetCarsByColor(string color)
        {
            return _vehicles.OfType<CarModel>().Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)); // Büyük küçük harf bakmaksızın arama yap.
        }

        public IEnumerable<VehicleModel> GetBusesByColor(string color)
        {
            return _vehicles.OfType<BusModel>().Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<VehicleModel> GetBoatsByColor(string color)
        {
            return _vehicles.OfType<BoatModel>().Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
        }

        public CarModel FlipHeadlights(int carId)
        {
            var car = _vehicles.OfType<CarModel>().FirstOrDefault(c => c.Id == carId);
            if (car != null)
            {
                car.HeadlightsOn = !car.HeadlightsOn;
            }

            return car;
        }

        public bool DeleteCar(int carId)
        {
            var car = _vehicles.OfType<CarModel>().FirstOrDefault(c => c.Id == carId);
            if (car != null)
            {
                _vehicles.Remove(car);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
