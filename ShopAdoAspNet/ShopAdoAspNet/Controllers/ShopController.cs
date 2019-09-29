using AutoMapper;
using LinqKit;
using ShopAdo.BLL.DTO;
using ShopAdo.BLL.Services;
using ShopAdoAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class ShopController : Controller
    {
        private readonly IService<GoodDTO> _goodService;
        private readonly IService<CategoryDTO> _categoryService;
        private readonly IService<ManufacturerDTO> _manufacturerService;
        private readonly IService<PhotoDTO> _photoService;
        private readonly IMapper _mapper;

        public ShopController(IService<GoodDTO> goodService, IService<CategoryDTO> categoryService, IService<ManufacturerDTO> manufacturerService, IService<PhotoDTO> photoService)
        {
            _goodService = goodService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            _photoService = photoService;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GoodDTO, DisplayGoodViewModel>();
                cfg.CreateMap<DisplayGoodViewModel, GoodDTO>();
            });
            _mapper = configuration.CreateMapper();
        }

        public ActionResult Index()
        {
            var categories = new List<CheckBoxFor<CategoryDTO>>();
            var manufacturers = new List<CheckBoxFor<ManufacturerDTO>>();

            foreach (var item in _categoryService.GetAll())
                categories.Add(new CheckBoxFor<CategoryDTO> { Item = item, IsChecked = false });

            foreach (var item in _manufacturerService.GetAll())
                manufacturers.Add(new CheckBoxFor<ManufacturerDTO> { Item = item, IsChecked = false });

            var filter = new GoodFilter
            {
                Categories = categories,
                Manufacturers = manufacturers,
                PriceFrom = 0,
                PriceTo = (double)_goodService.GetAll().OrderByDescending(x => x.Price).FirstOrDefault().Price
            };

            return View(new FilterGoodsViewModel { Filter = filter, Goods = new List<DisplayGoodViewModel>() });
        }

        [HttpPost]
        public ActionResult Index(GoodFilter filter)
        {
            var predicate = PredicateBuilder.New<GoodDTO>();
            predicate.And(x => (double)x.Price >= filter.PriceFrom);
            predicate.And(x => (double)x.Price <= filter.PriceTo);

            var predicateCategory = PredicateBuilder.New<GoodDTO>();
            foreach (var item in filter.Categories)
            {
                var predicateConcrete = PredicateBuilder.New<GoodDTO>();

                predicateConcrete.And(x => item.IsChecked);
                predicateConcrete.And(x => x.CategoryId == item.Item.CategoryId);

                predicateCategory.Extend(predicateConcrete);
            }

            var predicateManufacturer = PredicateBuilder.New<GoodDTO>();
            foreach (var item in filter.Manufacturers)
            {
                var predicateConcrete = PredicateBuilder.New<GoodDTO>();

                predicateConcrete.And(x => item.IsChecked);
                predicateConcrete.And(x => x.ManufacturerId == item.Item.ManufacturerId);

                predicateManufacturer.Extend(predicateConcrete);
            }

            predicate.Extend(predicateCategory, PredicateOperator.And);
            predicate.Extend(predicateManufacturer, PredicateOperator.And);

            var goods = new List<DisplayGoodViewModel>();
            foreach (var i in _goodService.FindBy(predicate))
            {
                goods.Add(_mapper.Map<DisplayGoodViewModel>(i));
            }
            return View(new FilterGoodsViewModel { Filter = filter, Goods = goods });
        }
    }
}