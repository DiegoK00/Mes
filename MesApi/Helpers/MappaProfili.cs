using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MesApi.Dto;
using MesApi.Models;

namespace MesApi.Helpers
{
    public class MappaProfili : Profile
    {
        public MappaProfili()   
        {
            CreateMap<Commesse, CommesseDto>().ReverseMap();
            CreateMap<Utenti, UserDto>().ReverseMap();

        }
                
    }
}