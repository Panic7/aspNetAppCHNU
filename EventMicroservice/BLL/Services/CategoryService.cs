using AutoMapper;
using EventMicroservice.BLL.DTOs;
using EventMicroservice.DAL.Entities;
using EventMicroservice.DAL.Pagination.Parameters;
using EventMicroservice.DAL.Pagination;
using EventMicroservice.Repository;

namespace EventMicroservice.BLL.Services
{
    public class CategoryService
    {

        private readonly CategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(CategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var category = await categoryRepository.GetAsync(id);

            return mapper.Map<CategoryDTO>(category);
        }
        public async Task<CategoryDTO> GetAsync(string name)
        {
            var category = await categoryRepository.GetAsync(name);

            return mapper.Map<CategoryDTO>(category);
        }

        public async Task<Category> CreateAsync(CategoryDTO dto)
        {
            dto.Id = null;
            var category = mapper.Map<Category>(dto);
            var createdCategory = await categoryRepository.CreateAsync(category);

            return createdCategory;
        }

        public async Task UpdateAsync(CategoryDTO dto)
        {
            await categoryRepository.UpdateAsync(mapper.Map<Category>(dto));
        }

        public async Task DeleteAsync(int id)
        {
            await categoryRepository.DeleteAsync(id);
        }

    }
}
