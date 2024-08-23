namespace DroneAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }

        public ICollection<Drone>? Drones { get; set; }
    }
}
