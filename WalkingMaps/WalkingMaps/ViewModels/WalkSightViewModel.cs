using System;

namespace WalkingMaps.Entities
{
    public class WalkSightViewModel
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public string Address { get; set; }
        public int WalkId { get; set; }       
        public string WalkName { get; set; }
        public string PhotoUri { get; set; }
    }
}
