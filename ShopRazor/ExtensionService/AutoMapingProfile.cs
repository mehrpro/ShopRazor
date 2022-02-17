using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Netyar.DTO.CompaniesDTO;

namespace Netyar.ExtensionService
{
    public class AutoMapingProfile : Profile
    {
        public AutoMapingProfile()
        {
            CreateMap<CompanyEditDTO, Company>().ReverseMap();
            CreateMap<Company, CompanyDeleteDTO>().ReverseMap();
        }
    }
}
