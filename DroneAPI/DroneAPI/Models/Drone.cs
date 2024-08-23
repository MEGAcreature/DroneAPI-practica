namespace DroneAPI.Models
{
    public class Drone
    {
        public int DroneID { get; set; }
        public int SerialNumber { get; set; }
        public string? Model { get; set; }
        public int UserID { get; set; }

        public User? User { get; set; }
        public ICollection<Snapshot>? Snapshots { get; set; }

    }
}
