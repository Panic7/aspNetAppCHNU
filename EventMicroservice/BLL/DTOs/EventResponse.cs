namespace EventMicroservice.BLL.DTOs
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EventDate { get; set; }
        public int PeopleCapacity { get; set; }
        public int SubscribedUsersAmount { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public UserDTO Author { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}
