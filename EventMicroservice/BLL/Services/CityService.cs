using AutoMapper;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repository;

namespace EventMicroservice.BLL.Services
{
    public class CityService
    {
        private readonly CityRepository cityRepository;
        private readonly IMapper mapper;

        public CityService(CityRepository cityRepository, IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }

        public async Task<CityDTO> GetAsync(int id)
        {
            var city = await cityRepository.GetAsync(id);

            return mapper.Map<CityDTO>(city);
        }
        public async Task<CityDTO> GetAsync(string name)
        {
            var city = await cityRepository.GetAsync(name);

            return mapper.Map<CityDTO>(city);
        }

        public async Task<City> CreateAsync(CityDTO dto)
        {
            dto.Id = null;
            var city = mapper.Map<City>(dto);
            var createdCity = await cityRepository.CreateAsync(city);

            return createdCity;
        }

        public async Task UpdateAsync(CityDTO dto)
        {
            await cityRepository.UpdateAsync(mapper.Map<City>(dto));
        }

        public async Task DeleteAsync(int id)
        {
            await cityRepository.DeleteAsync(id);
        }
    }
}