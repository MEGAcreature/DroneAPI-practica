using DroneAPI.Models;

namespace DroneAPI.Services
{
    public class DroneService
    {
        static List<Drone> Drones {  get; }
        static int nextId = 4;
        static DroneService()
        {
            Drones = new List<Drone>
            {
                new Drone() {DroneID = 0, SerialNumber = 123, Model = "Fly1", UserID = 1},
                new Drone() {DroneID = 1, SerialNumber = 145, Model = "Fly2", UserID = 1},
                new Drone() {DroneID = 2, SerialNumber = 155, Model = "Fly3", UserID = 1},
                new Drone() {DroneID = 3, SerialNumber = 167, Model = "Fly4", UserID = 1},
            };
        }

        public static List<Drone> GetAll() => Drones;

        public static Drone? Get(int id) => Drones.FirstOrDefault(d => d.DroneID == id);
    
        public static void Add(Drone drone)
        {
            drone.DroneID = nextId++;
            Drones.Add(drone);
        }

        public static void Delete(int id)
        {
            var drone = Get(id);
            if (drone is null)
                return;
            Drones.Remove(drone);
        }

        public static void Update(Drone drone)
        {
            var index = Drones.FindIndex(d => d.DroneID == drone.DroneID);
            if (index < 0)
            {
                return;
            }
            Drones[index] = drone;
        }
    }
}
