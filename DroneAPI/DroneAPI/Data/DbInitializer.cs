using DroneAPI.Models;

namespace DroneAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(DroneContext context)
        {
            context.Database.EnsureCreated();

            if (context.Drones.Any())
            {
                return; // DB has been seeded
            }

            var users = new User[]
            {
                new User{Id=0,Name="Atti",Email="atti@mail.com",Password="password",IsAdmin=true},
                new User{Id=1,Name="Csaba",Email="csaba@mail.com",Password="password",IsAdmin=true},
                new User{Id=2,Name="Dani",Email="dani@mail.com",Password="password",IsAdmin=false},
                new User{Id=3,Name="Heni",Email="heni@mail.com",Password="password",IsAdmin=false},
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var drones = new Drone[]
            {
                new Drone{Id=0,Model="Samsung",SerialNumber=123,OwnerId=1},
                new Drone{Id=1,Model="Samsung",SerialNumber=222,OwnerId=1},
                new Drone{Id=2,Model="Samsung",SerialNumber=234,OwnerId=2},
                new Drone{Id=3,Model="Samsung",SerialNumber=334,OwnerId=2},
                new Drone{Id=4,Model="Samsung",SerialNumber=155,OwnerId=0},
                new Drone{Id=5,Model="Samsung",SerialNumber=126,OwnerId=0},
                new Drone{Id=6,Model="Samsung",SerialNumber=476,OwnerId=3},
            };
            foreach (Drone drone in drones)
            {
                context.Drones.Add(drone);
            }
            context.SaveChanges();

            var snapshots = new Snapshot[]
            {
                new Snapshot{Id=0,DroneId=0,Longitude=15.33f,Latitude=15.33f,Altitude=500,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{Id=1,DroneId=0,Longitude=16.33f,Latitude=30.33f,Altitude=300,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{Id=2,DroneId=0,Longitude=17.33f,Latitude=19.33f,Altitude=400,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{Id=3,DroneId=1,Longitude=18.33f,Latitude=17.33f,Altitude=1100,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{Id=4,DroneId=1,Longitude=19.33f,Latitude=20.33f,Altitude=700,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{Id=5,DroneId=2,Longitude=20.33f,Latitude=21.33f,Altitude=800,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{Id=6,DroneId=3,Longitude=23.33f,Latitude=5.33f,Altitude=100,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{Id=7,DroneId=4,Longitude=55.33f,Latitude=23.33f,Altitude=50,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{Id=8,DroneId=5,Longitude=6.33f,Latitude=19.33f,Altitude=340,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{Id=9,DroneId=5,Longitude=5.33f,Latitude=14.33f,Altitude=200,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"}
            };
            foreach (Snapshot snapshot in snapshots)
            {
                context.Snapshots.Add(snapshot);
            }
            context.SaveChanges();

        }
    }
}
