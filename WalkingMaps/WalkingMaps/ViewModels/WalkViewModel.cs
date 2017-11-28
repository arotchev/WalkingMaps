using System;
using WalkingMaps.Entities;

namespace WalkingMaps.ViewModels
{
    
    public class WalkViewModel
    {         
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime CreatedDate { get; set; }
        public string NavLink { get; set; }
        public decimal? Distance { get; set; }
        public bool IsPublished { get; set; }
        public  string UserId { get; set; }
        public City City { get; set; }    
        public int TotalSights { get; set; }
    }
}
