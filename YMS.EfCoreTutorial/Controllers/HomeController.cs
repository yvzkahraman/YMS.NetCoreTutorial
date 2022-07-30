using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Roles="Member")]
        public IActionResult Index()
        {
            YMSContext context = new YMSContext();
            List<Employee> employees = context.Employees.ToList();

            return View(employees);
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            // Validation Login register cookie based auth / devextreme

            // 
            return View(new CreateEmployeeRequestModel());
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeRequestModel employeeRequestModel)
        {
            //AutoMapper
            YMSContext context = new YMSContext();
            // Tracking 
            var mappedData = _mapper.Map<Employee>(employeeRequestModel);
            




            context.Employees.Add(mappedData);
            // herhangi bir komut gitmez.

           
           var entry =  context.Entry(mappedData);

            context.SaveChanges();

            // ef nasıl oluyorda bu add'i gördüğünde eklemeyi nasıl yapar.
            // entrystate=> state 


            //if(effectedRows > 0)
            //{
            //    // başarılı
            //}
            //effected rows
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
    }
}
