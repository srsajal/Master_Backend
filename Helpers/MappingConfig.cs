using AutoMapper;
using master.DAL.Entity;
using master.Models;
using MasterManegmentSystem.Models;

namespace master.Helpers
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<masterDDOModel, Ddo>().ReverseMap();
            CreateMap<masterSCHEME_HEADModel, SchemeHead>().ReverseMap();
            CreateMap<masterDepartmentModel, Department>().ReverseMap();
            CreateMap<MasterManegmentModel, MajorHead>().ReverseMap();

        }
    }
}
