using System;
using System.Collections.Generic;

namespace WalkingMaps.Entities
{
    public class Sight : IEntityBase
    {
        public Sight()
        {
            SightWalks = new List<WalkSight>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NavLink { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FormattedAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string UserId { get; set; }      
        public virtual ICollection<WalkSight> SightWalks { get; set; }
        public string PhotoUri { get; set; }
        public string Author { get; set; }
    }
}
