using AutoMapper.Configuration;
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
    public class GoodService : IService<GoodDTO>
    {
        private readonly IRepository<Good> _repository;
        private readonly IMapper _mapper;

        public GoodService(IRepository<Good> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddOrUpdate(GoodDTO obj)
        {
            var good = _mapper.Map<Good>(obj);
            _repository.AddOrUpdate(good);
        }

        public void Delete(GoodDTO obj)
        {
            _repository.Delete(obj.GoodId);
        }

        public IEnumerable<GoodDTO> FindBy(Expression<Func<GoodDTO, bool>> predicate)
        {
            return _repository.GetAll().Select(obj => _mapper.Map<GoodDTO>(obj)).Where(predicate.Compile());
        }

        public GoodDTO Get(int id)
        {
            var good = _repository.Get(id);
            return _mapper.Map<GoodDTO>(good);
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return _repository.GetAll().Select(obj => _mapper.Map<GoodDTO>(obj));
        }
    }
}
