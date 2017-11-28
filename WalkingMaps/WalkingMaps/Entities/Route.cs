using System;
using System.Collections.Generic;

namespace WalkingMaps.Entities
{
    public class Route : IEntityBase
    {
        public Route()
        {
            Points = new List<Point>();
        }

        public int Id { get; set; }
        public int WalkId { get; set; }       
        public virtual Walk Walk { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Point> Points { get; set; }
    }
}
