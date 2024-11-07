using AutoMapper;
using GymManagerBlazor.BUS.Models;
using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MemberViewModel, MemberModel>().ReverseMap();
            CreateMap<ClassViewModel, ClassModel>().ReverseMap();
            CreateMap<TrainerViewModel, TrainerModel>().ReverseMap();
            CreateMap<ClassRegistrationViewModel, ClassRegistrationModel>().ReverseMap();
        }
    }
}
