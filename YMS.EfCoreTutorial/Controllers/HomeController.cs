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

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            YMSContext context = new YMSContext();
            List<Employee> employees = context.Employees.AsNoTracking().ToList();

            

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
            if (ModelState.IsValid)
            {
                //AutoMapper
                YMSContext context = new YMSContext();
                // Tracking 
                var mappedData = _mapper.Map<Employee>(employeeRequestModel);

                context.Employees.Add(mappedData);
                // herhangi bir komut gitmez.


                var entry = context.Entry(mappedData);

                context.SaveChanges();

                // ef nasıl oluyorda bu add'i gördüğünde eklemeyi nasıl yapar.
                // entrystate=> state 


                //if(effectedRows > 0)
                //{
                //    // başarılı
                //}
                //effected rows
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            YMSContext ymsContext = new YMSContext();
            var deletedEntity = ymsContext.Employees.Find(id);
            if (deletedEntity != null)
            {
                ymsContext.Employees.Remove(deletedEntity);
                ymsContext.SaveChanges();
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
            YMSContext context = new YMSContext();

            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var context = new YMSContext();
            var updatedEmployee = context.Employees.AsNoTracking().SingleOrDefault(x=>x.Id == id);
            var mappedData = _mapper.Map<UpdateEmployeeModel>(updatedEmployee);

            return View(mappedData);
        }

        [HttpPost]
        public IActionResult Update(UpdateEmployeeModel model)
        {
            var context = new YMSContext();
            var updatedEntity = context.Employees.SingleOrDefault(x=>x.Id == model.Id);

            updatedEntity.Name = model.Name;
            updatedEntity.Surname = model.Surname;


            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
