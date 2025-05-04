﻿namespace TaftMasterWebAPI.Models
{
    public class RugRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool Agreement { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
