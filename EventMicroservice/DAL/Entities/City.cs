namespace EventMicroservice.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Event> Events { get; set; }
        public List<User> Users { get; set; }
    }
}
