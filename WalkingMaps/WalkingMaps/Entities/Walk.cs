using System.Collections.Generic;
using System;

namespace WalkingMaps.Entities
{
    public class Walk : IEntityBase
    {
        public Walk()
        {
            WalkSights = new List<WalkSight>();
        }        
       
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
        public virtual ICollection<WalkSight> WalkSights { get; set; }
        public virtual Route Route { get; set; }
    }
}
