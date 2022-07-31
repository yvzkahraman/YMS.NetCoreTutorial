using AutoMapper;
using YMS.EfCoreTutorial.Entities;
using YMS.EfCoreTutorial.Models;

namespace YMS.EfCoreTutorial.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            this.CreateMap<CreateEmployeeModel, Employee>().ReverseMap();
            this.CreateMap<UpdateEmployeeModel,Employee>().ReverseMap();
        }
    }
}
