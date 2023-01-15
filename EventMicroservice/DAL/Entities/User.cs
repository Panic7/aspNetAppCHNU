namespace EventMicroservice.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public Role Role { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public List<Event> SubscribedEvents { get; set; }
        public List<Event> CreatedEvents { get; set; }

    }
}
