using AutoMapper;
using GarageSmille.Domain.Entities;
using GarageSmille_Ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSmille_Ui.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<LogInViewModel, Usuario>().ReverseMap();
                //x.CreateMap<Evento, EventoViewModel>().ReverseMap();
            });
        }
    }
}