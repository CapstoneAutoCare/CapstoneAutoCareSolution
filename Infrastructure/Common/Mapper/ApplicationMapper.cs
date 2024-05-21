using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.ModelSecurity;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response;
using Infrastructure.Common.Response.ResponseAdmin;
using Infrastructure.Common.Response.ResponseClient;
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

            CreateMap<Admin, ResponseAdmin>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.AdminId, act => act.MapFrom(src => src.AdminId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role));



            CreateMap<Client, ResponseClient>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.ClientId, act => act.MapFrom(src => src.ClientId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday));

            CreateMap<AccessToken, AuthenResponseMessToken>()
                .ForMember(p => p.Token, act => act.MapFrom(src => src.Token))
                .ForMember(p => p.Expiration, act => act.MapFrom(src => src.ExpirationTicks))
                .ForMember(p => p.RefreshToken, act => act.MapFrom(src => src.RefreshToken.Token));
        }
    }
}
