using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerimCase.Business.Abstract.Query;
using SerimCase.Business.Abstract.Service;
using SerimCase.Entities.Concrete;
using SerimCase.ViewModels;

namespace SerimCase.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IDynamicQuery _dynamicQuery;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService,IDynamicQuery dynamicQuery,IMapper mapper)
        {
            _customerService = customerService;
            _dynamicQuery = dynamicQuery;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _customerService.CustomerList(null);
            return View(list);
        }

        public async Task<IActionResult> GetCustomerList(bool isActive)
        {
            var customers = await _customerService.CustomerList(isActive);
            return PartialView("_CustomerList", customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Geçersiz veri." });
            }

            int result = await _customerService.AddCustomer(viewModel);

            if (result > 0)
            {
                TempData["status"] = "Müşteri başarıyla eklendi!";
                return Json(new { success = true, message = "Müşteri başarıyla eklendi!" });

            }

            return Json(new { success = false, message = "Müşteri eklenirken bir hata oluştu." });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateViewModel viewModel)
        {
        
            int result = await _customerService.UpdateCustomer(viewModel);

            if (result > 0)
            {
                TempData["status"] = "Kayıt güncellendi";

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);

        }

        public async Task<IActionResult> UpdateCustomer(int id)
        {
            Customer customer = await _dynamicQuery.GetAsync<Customer>(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<CustomerUpdateViewModel>(customer);

            ViewBag.Gender = customer.Gender;

            return View(viewModel);
        }

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET","POST")]

        public async Task<IActionResult> HasCustomerEmail(string Email)
        {
            var anyEmail = await _dynamicQuery.GetAllAsync<Customer>($"Email='{Email}'");

            if (anyEmail.Count>0)
            {
                return Json("Bu email zaten var.");
            }
            else
            {
                return Json(true);
            }
        }

    }
}
