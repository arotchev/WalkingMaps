namespace WalkingMaps.Entities
{
    public class Point : IEntityBase
    {
      
        public int Id { get; set; }      
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int RouteId { get; set; }       
        public virtual Route Route { get; set; }
    }
}
