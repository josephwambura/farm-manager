﻿using AutoMapper;
using Entities;
using Entities.Models;

namespace Repositories.Mappers
{
    public class FactoryMapper : Profile
    {
        public FactoryMapper()
        {
            CreateMap<Factory, FactoryModel>();
        }

        public static Factory CreateFactory(FactoryModel model)
        {
            var factory = new Factory();

            factory.SetNewId();

            factory.FactoryName = model.FactoryName;

            factory.PhoneNumber = model.PhoneNumber;

            factory.Location = model.Location;

            factory.CreatedDate = DateTime.Now;

            return factory;
        }


    }
}
