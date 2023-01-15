namespace EventMicroservice.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }
        public List<User> Users { get; set; }
        public List<City> Cities { get; set; }
    }
}
