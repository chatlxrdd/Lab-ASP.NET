using Data.Entities;
using Lab_ASPNET.Enum;
using Lab_ASPNET.Models;
using System.Diagnostics;

namespace Lab_ASPNET.Mappers
{
    public class ProducerMapper    // Title Regon Nip Company
    {
        public static Producer FromEntity(ProducerEntity entity)
        {
            return new Producer()
            {
                Id = entity.Id,
                Title = entity.Title,
                Regon = entity.Regon,
                Nip = entity.Nip,
            };
        }

        public static ProducerEntity ToEntity(Producer model)
        {
            return new ProducerEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Regon = model.Regon,
                Nip = model.Nip,
            };
        }
    }
}