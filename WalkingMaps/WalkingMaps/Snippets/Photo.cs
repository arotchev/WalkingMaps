using System;

namespace WalkingMaps.Entities
{
    public class Photo : IEntityBase
    {

        public int Id { get; set; }      
        public string Title { get; set; }
        public string Uri { get; set; }      
        public int SightId { get; set; }
        public virtual Sight Sight { get; set; }
        public string UserId { get; set; }
        public DateTime DateUploaded { get; set; }
    }
}
