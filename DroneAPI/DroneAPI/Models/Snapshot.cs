﻿namespace DroneAPI.Models
{
    public class Snapshot
    {
        public int SnapshotID { get; set; }
        public float Longitude { get; set; }
        public float Altitude{ get; set; }
        public float Latitude { get; set; }
        public int DroneId { get; set; }    
        public DateTime DateTime { get; set; }
        public string Description { get; set; } 
    
        public Drone Drone { get; set; }
    }
}
