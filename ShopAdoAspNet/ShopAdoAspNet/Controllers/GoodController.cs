using AutoMapper;
using ShopAdo.BLL.DTO;
using ShopAdo.BLL.Services;
using ShopAdoAspNet.Models;
using ShopAdoAspNet.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class GoodController : Controller
    { 
        private readonly IService<GoodDTO> _goodService;
        private readonly IService<CategoryDTO> _categoryService;
        private readonly IService<ManufacturerDTO> _manufacturerService;
        private readonly IService<PhotoDTO> _photoService;
        private readonly IMapper _mapper;

        public GoodController(IService<GoodDTO> goodService, IService<CategoryDTO> categoryService, IService<ManufacturerDTO> manufacturerService, IService<PhotoDTO> photoService)
        {
            _goodService = goodService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            _photoService = photoService;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GoodDTO, CreateGoodViewModel>()
                        .ForMember("Photos", opt => opt.MapFrom(good => _photoService.GetAll().Where(x => x.GoodId == good.GoodId).ToList()))
                        .ForMember("Manufacturers", opt => opt.MapFrom(good => new SelectList(_manufacturerService.GetAll(), "ManufacturerId", "ManufacturerName")))
                        .ForMember("Categories", opt => opt.MapFrom(good => new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName")));
                cfg.CreateMap<CreateGoodViewModel, GoodDTO>();
            });
            _mapper = configuration.CreateMapper();
        }

        public ActionResult Index()
        {
            return View(_goodService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_goodService.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _goodService.Delete(_goodService.Get(id));
            return RedirectToAction("Index", "Good");
        }

        public ActionResult Edit(int id)
        {
            var good = _goodService.Get(id);
            var viewModel = _mapper.Map<CreateGoodViewModel>(good);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CreateGoodViewModel viewModel, IEnumerable<HttpPostedFileBase> fileUpload)
        {
            var good = _mapper.Map<GoodDTO>(viewModel);

            foreach (var photo in fileUpload)
            {
                if (photo == null)
                    break;

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploaded/");
                string filename = Path.GetFileName(photo.FileName);
                string pathToFile = Path.Combine(path, filename);
                if (filename != null)
                    photo.SaveAs(pathToFile);

                _photoService.AddOrUpdate(new PhotoDTO { GoodId = good.GoodId, PhotoPath = pathToFile });
            }

            _goodService.AddOrUpdate(good);
            return RedirectToAction("Index", "Good");
        }

        public ActionResult Add()
        {
            var viewModel = _mapper.Map<CreateGoodViewModel>(new GoodDTO());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(CreateGoodViewModel viewModel, IEnumerable<HttpPostedFileBase> fileUpload)
        {
            var good = _mapper.Map<GoodDTO>(viewModel);

            foreach (var photo in fileUpload)
            {
                if (photo == null)
                    break;

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploaded/");
                string filename = Path.GetFileName(photo.FileName);
                string pathToFile = Path.Combine(path, filename);
                if (filename != null)
                    photo.SaveAs(pathToFile);

                _photoService.AddOrUpdate(new PhotoDTO { GoodId = good.GoodId, PhotoPath = pathToFile });
            }

            _goodService.AddOrUpdate(good);
            return RedirectToAction("Index", "Good");
        }
    }
}