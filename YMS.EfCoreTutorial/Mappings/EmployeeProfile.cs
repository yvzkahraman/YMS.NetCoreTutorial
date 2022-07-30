using AutoMapper;
using YMS.EfCoreTutorial.Entities;
using YMS.EfCoreTutorial.Models;

namespace YMS.EfCoreTutorial.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            this.CreateMap<CreateEmployeeRequestModel, Employee>().ReverseMap();
        }
    }
}
