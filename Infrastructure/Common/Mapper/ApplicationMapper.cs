using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CreateClient, Client>()
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday))
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));

            CreateMap<CreateAdmin, Admin>()
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));
        }
    }
}
