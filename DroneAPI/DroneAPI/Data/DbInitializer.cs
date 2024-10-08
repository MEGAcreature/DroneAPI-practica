﻿using DroneAPI.Models;

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
                new User{Name="Atti",Email="atti@mail.com",Password="password",IsAdmin=true},
                new User{Name="Csaba",Email="csaba@mail.com",Password="password",IsAdmin=true},
                new User{Name="Dani",Email="dani@mail.com",Password="password",IsAdmin=false},
                new User{Name="Heni",Email="heni@mail.com",Password="password",IsAdmin=false},
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var drones = new Drone[]
            {
                new Drone{Model="Samsung",SerialNumber=123,UserID=1},
                new Drone{Model="Samsung",SerialNumber=222,UserID=1},
                new Drone{Model="Samsung",SerialNumber=234,UserID=2},
                new Drone{Model="Samsung",SerialNumber=334,UserID=2},
                new Drone{Model="Samsung",SerialNumber=155,UserID=4},
                new Drone{Model="Samsung",SerialNumber=126,UserID=4},
                new Drone{Model="Samsung",SerialNumber=476,UserID=3},
            };
            foreach (Drone drone in drones)
            {
                context.Drones.Add(drone);
            }
            context.SaveChanges();

            var snapshots = new Snapshot[]
            {
                new Snapshot{DroneId=6,Longitude=15.33f,Latitude=15.33f,Altitude=500,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{DroneId=6,Longitude=16.33f,Latitude=30.33f,Altitude=300,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{DroneId=6,Longitude=17.33f,Latitude=19.33f,Altitude=400,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{DroneId=1,Longitude=18.33f,Latitude=17.33f,Altitude=1100,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{DroneId=1,Longitude=19.33f,Latitude=20.33f,Altitude=700,DateTime=DateTime.Parse("2024-08-10 07:00:32"),Description="pretty"},
                new Snapshot{DroneId=2,Longitude=20.33f,Latitude=21.33f,Altitude=800,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{DroneId=3,Longitude=23.33f,Latitude=5.33f,Altitude=100,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{DroneId=4,Longitude=55.33f,Latitude=23.33f,Altitude=50,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{DroneId=5,Longitude=6.33f,Latitude=19.33f,Altitude=340,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"},
                new Snapshot{DroneId=5,Longitude=5.33f,Latitude=14.33f,Altitude=200,DateTime=DateTime.Parse("2024-08-10 07:00:32"), Description = "pretty"}
            };
            foreach (Snapshot snapshot in snapshots)
            {
                context.Snapshots.Add(snapshot);
            }
            context.SaveChanges();

        }
    }
}
