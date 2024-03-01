using Data.Entities;
using Lab_ASPNET.Enum;
using Lab_ASPNET.Models;
using System.Diagnostics;

namespace Lab_ASPNET.Mappers
{
    public class ComputerMapper     //Computer - Id , Name, Processor, Memory, GraphicsCard, Manufacturer, ProductionDate, ProducerId, Producers , NotUsed;Used;BrandNew 
    {
        public static Computer FromEntity(ComputerEntity entity)      
        {
            return new Computer()             
            {
                Id = entity.Id,
                Name = entity.Name,
                Processor = entity.Processor,
                Memory = entity.Memory,
                GraphicsCard = entity.GraphicsCard,
                Manufacturer = entity.Manufacturer,
                ProductionDate = entity.ProductionDate,
                ProducerId = entity.ProducerId,
                Priority = (Priority)entity.Priority,
            };
        }

        public static ComputerEntity ToEntity(Computer model)
        {
            return new ComputerEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Processor = model.Processor,
                Memory = model.Memory,
                GraphicsCard = model.GraphicsCard,
                Manufacturer = model.Manufacturer,
                ProductionDate = model.ProductionDate,
                ProducerId = model.ProducerId,
                Priority = (int)model.Priority
            };
        }
    }
}
