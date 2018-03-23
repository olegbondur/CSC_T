using AutoMapper;
using CSC_T.Api.Models;
using CSC_T.BusinessLayer.Entities;

namespace CSC_T.Api.Mappers
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
            //:this("CSCProfile")
        {
            CreateMap<RegistrationViewModel, BaseUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }

        //protected AutoMapperProfileConfiguration(string profileName)
        //    :base(profileName)
        //{
        //}
    }
}
