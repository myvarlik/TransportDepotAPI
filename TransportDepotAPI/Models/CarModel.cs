namespace TransportDepotAPI.Models
{
    public class CarModel : VehicleModel
    {
        public int NumberOfWheels { get; set; } = 4;
        public bool HeadlightsOn { get; set; } = false;
    }
}
