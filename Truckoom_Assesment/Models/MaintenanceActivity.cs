using System.ComponentModel.DataAnnotations;

namespace Truckoom_Assesment.Models
{
    public class MaintenanceActivity
    {

        public int MaintenanceID { get; set; } // Primary Key
        public int VehicleID { get; set; }
        public string MaintenanceType { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
