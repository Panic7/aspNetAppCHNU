using AutoMapper;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.DAL.Entities;
using EventMicroservice.Repository;
using System.Diagnostics.Metrics;

namespace EventMicroservice.BLL.Services
{
    public class CountryService
    {
        private readonly CountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountryService(CountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        public async Task<CountryDTO> GetAsync(int id)
        {
            var country = await countryRepository.GetAsync(id);

            return mapper.Map<CountryDTO>(country);
        }
        public async Task<CountryDTO> GetAsync(string name)
        {
            var country = await countryRepository.GetAsync(name);

            return mapper.Map<CountryDTO>(country);
        }

        public async Task<Country> CreateAsync(CountryDTO dto)
        {
            dto.Id = null;
            var country = mapper.Map<Country>(dto);
            var createdCountry = await countryRepository.CreateAsync(country);

            return createdCountry;
        }

        public async Task UpdateAsync(CountryDTO dto)
        {
            await countryRepository.UpdateAsync(mapper.Map<Country>(dto));
        }

        public async Task DeleteAsync(int id)
        {
            await countryRepository.DeleteAsync(id);
        }
    }
}
