namespace EventMicroservice.DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EventDate { get; set; }
        public int PeopleCapacity { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public List<User> SubscribedUsers { get; set; }
        public List<Category> Categories { get; set; }

    }
}
