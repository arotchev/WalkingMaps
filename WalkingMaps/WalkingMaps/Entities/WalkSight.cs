using System;

namespace WalkingMaps.Entities
{
    public class WalkSight: IEntityBase
    {
        public int Id { get; set; }
        public int WalkId { get; set; }
        public int SightId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Walk Walk{ get; set; }
        public virtual Sight Sight { get; set; }
    }
}
