using AutoMapper;
using ShopAdo.BLL.DTO;
using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddOrUpdate(CategoryDTO obj)
        {
            var category = _mapper.Map<Category>(obj);
            _repository.AddOrUpdate(category);
        }

        public void Delete(CategoryDTO obj)
        {
            _repository.Delete(obj.CategoryId);
        }

        public IEnumerable<CategoryDTO> FindBy(Expression<Func<CategoryDTO, bool>> predicate)
        {
            return _repository.GetAll().Select(obj => _mapper.Map<CategoryDTO>(obj)).Where(predicate.Compile());
        }

        public CategoryDTO Get(int id)
        {
            var category = _repository.Get(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _repository.GetAll().Select(obj => _mapper.Map<CategoryDTO>(obj));
        }
    }
}
