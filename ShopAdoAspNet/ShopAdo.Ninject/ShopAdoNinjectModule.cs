using AutoMapper;
using Ninject;
using Ninject.Modules;
using ShopAdo.BLL.DTO;
using ShopAdo.BLL.Services;
using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.Ninject
{
    public class ShopAdoNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<IRepository<Photo>>().To<PhotoRepository>();

            Bind<IService<GoodDTO>>().To<GoodService>().WithConstructorArgument("repository", Kernel.Get<IRepository<Good>>());
            Bind<IService<ManufacturerDTO>>().To<ManufacturerService>().WithConstructorArgument("repository", Kernel.Get<IRepository<Manufacturer>>());
            Bind<IService<CategoryDTO>>().To<CategoryService>().WithConstructorArgument("repository", Kernel.Get<IRepository<Category>>());
            Bind<IService<PhotoDTO>>().To<PhotoService>().WithConstructorArgument("repository", Kernel.Get<IRepository<Photo>>());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Photo, PhotoDTO>().ReverseMap();
                cfg.CreateMap<Good, GoodDTO>()
                    .ForMember("ManufacturerName", opt => opt.MapFrom(good => good.Manufacturer.ManufacturerName))
                    .ForMember("CategoryName", opt => opt.MapFrom(good => good.Category.CategoryName)).ReverseMap();
            });
            var mapper = mapperConfiguration.CreateMapper();
            Bind<IMapper>().ToConstant<IMapper>(mapper);
        }
    }
}
