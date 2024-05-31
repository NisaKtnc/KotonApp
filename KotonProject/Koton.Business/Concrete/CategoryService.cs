using Koton.Business.Abstract;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Koton.Business.DTO_s;
using AutoMapper;


namespace Koton.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public async Task<Category> AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            return category;
        }

        public async Task<Category> DeleteCategoryById(int Id)
        {
            var category = await _categoryRepository.GetByIdAsync(Id);
            if (category == null)

                throw new Exception("Category is not found");

            await _categoryRepository.DeleteAsync(category);
            return category;
        }
        public async Task<IEnumerable<Entities.Models.Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int Id)
        {
            return await _categoryRepository.GetByIdAsync(Id);
        }

        public async Task<Category> UpdateCategory(CategoryDto categoryDto)
        {
            var update = _mapper.Map<Category>(categoryDto);  
            await _categoryRepository.UpdateAsync(update);
            return update;  

        }
    }
}
