namespace Truckoom_Assesment.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public object? VehicleId { get; internal set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public ICollection<MaintenanceActivity> MaintenanceActivities { get; set; }
    }

}
