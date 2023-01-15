namespace EventMicroservice.BLL.DTOs;

public class EventRequest
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? EventDate { get; set; }
    public int? PeopleCapacity { get; set; }
    public int? CountryId { get; set; }
    public int? CityId { get; set; }
    public int? AuthorId { get; set; }
    public int[]? CategoryIDs { get; set; }
}
