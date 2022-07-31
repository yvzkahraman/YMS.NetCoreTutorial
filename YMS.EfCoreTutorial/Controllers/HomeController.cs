using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YMS.EfCoreTutorial.Contexts;
using YMS.EfCoreTutorial.Entities;
using YMS.EfCoreTutorial.Models;

namespace YMS.EfCoreTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly YMSContext _context;

        public HomeController(IMapper mapper, YMSContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [Authorize]
        public IActionResult Secure()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Employee> employees = _context.Employees.AsNoTracking().ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Validation Login register cookie based auth / devextreme
            // 
            return View(new CreateEmployeeModel());
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeModel employeeRequestModel)
        {
            // <input asp-for ="@Model.Name" /> 
            // <input Name="Name" id="Name" value = @Model.Name />
            // custom tag helper viewComponent => kendi kendilerine bir controller veya action ihtiyacı olmadan çalışabilmeli
            // asp-for asp-validation-for asp-action asp-controller asp-route
            if (ModelState.IsValid)
            {

                var mappedData = _mapper.Map<Employee>(employeeRequestModel);
                _context.Employees.Add(mappedData);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRequestModel);

        }

        public IActionResult Remove(int id)
        {

            var deletedEntity = _context.Employees.Find(id);
            if (deletedEntity != null)
            {
                _context.Employees.Remove(deletedEntity);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        public IActionResult DummyCreate()
        {
            var employee = new Employee();
            employee.Name = "deneme";
            employee.Surname = "deneme";
            employee.Addresses = new List<Address>
            {
                new Address
                {
                    Definition="Adres 1"
                }
            };


            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            // Microsoft.Extensions.DependencyInjection
            //Dependency Injection => Dependency Inversion  => Bağımlı Olma !!! 

            var updatedEmployee = _context.Employees.AsNoTracking().SingleOrDefault(x => x.Id == id);
            var mappedData = _mapper.Map<UpdateEmployeeModel>(updatedEmployee);

            return View(mappedData);
        }

        [HttpPost]
        public IActionResult Update(UpdateEmployeeModel model)
        {
            if (ModelState.IsValid)
            {

                var updatedEntity = _context.Employees.SingleOrDefault(x => x.Id == model.Id);

                updatedEntity.Name = model.Name;
                updatedEntity.Surname = model.Surname;


                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
