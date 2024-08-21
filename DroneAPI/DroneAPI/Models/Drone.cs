namespace DroneAPI.Models
{
    public class Drone
    {
        public int Id { get; set; }
     
        public int SerialNumber { get; set; }

        public string? Model { get; set; }

        public string? Owner { get; set; }

    }
}
