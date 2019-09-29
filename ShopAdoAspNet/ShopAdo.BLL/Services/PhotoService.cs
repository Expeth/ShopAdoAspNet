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
    public class PhotoService : IService<PhotoDTO>
    {
        private readonly IRepository<Photo> _repository;
        private readonly IMapper _mapper;

        public PhotoService(IRepository<Photo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddOrUpdate(PhotoDTO obj)
        {
            var photo = _mapper.Map<Photo>(obj);
            _repository.AddOrUpdate(photo);
        }

        public void Delete(PhotoDTO obj)
        {
            _repository.Delete(obj.PhotoId);
        }

        public IEnumerable<PhotoDTO> FindBy(Expression<Func<PhotoDTO, bool>> predicate)
        {
            return _repository.GetAll().Select(obj => _mapper.Map<PhotoDTO>(obj)).Where(predicate.Compile());
        }

        public PhotoDTO Get(int id)
        {
            var photo = _repository.Get(id);
            return _mapper.Map<PhotoDTO>(photo);
        }

        public IEnumerable<PhotoDTO> GetAll()
        {
            return _repository.GetAll().Select(obj => _mapper.Map<PhotoDTO>(obj));
        }
    }
}
