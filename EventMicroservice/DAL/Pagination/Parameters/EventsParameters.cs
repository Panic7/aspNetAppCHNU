namespace EventMicroservice.DAL.Pagination.Parameters
{
    public class EventsParameters : BasePaginationParameters
    {
        public int? CategoryId { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }
    }
}
