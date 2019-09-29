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
    public class ManufacturerService : IService<ManufacturerDTO>
    {
        private readonly IRepository<Manufacturer> _repository;
        private readonly IMapper _mapper;

        public ManufacturerService(IRepository<Manufacturer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddOrUpdate(ManufacturerDTO obj)
        {
            var manufacturer = _mapper.Map<Manufacturer>(obj);
            _repository.AddOrUpdate(manufacturer);
        }

        public void Delete(ManufacturerDTO obj)
        {
            _repository.Delete(obj.ManufacturerId);
        }

        public IEnumerable<ManufacturerDTO> FindBy(Expression<Func<ManufacturerDTO, bool>> predicate)
        {
            return _repository.GetAll().Select(obj => _mapper.Map<ManufacturerDTO>(obj)).Where(predicate.Compile());
        }

        public ManufacturerDTO Get(int id)
        {
            var manufacturer = _repository.Get(id);
            return _mapper.Map<ManufacturerDTO>(manufacturer);
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return _repository.GetAll().Select(obj => _mapper.Map<ManufacturerDTO>(obj));
        }
    }
}
