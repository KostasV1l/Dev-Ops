using System;
using Contentful.Core.Models;

namespace TravelDev.Models
{
    public class TravelAgency
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public Asset? DestinationImage { get; set; }
        public int? Rating { get; set; }
    }
    
}