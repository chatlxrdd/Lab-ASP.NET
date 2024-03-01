using System.Diagnostics;
using System;
using Lab_ASPNET.Models;
using Lab_ASPNET.Mappers;
using Data;
using Data.Entities;

namespace Lab_ASPNET.Services.Computery
{
    public class EFComputerService : IComputerService
    {
        private AppDbContext _context;
        public EFComputerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Computer computer)
        {
            var e = _context.Computers.Add(ComputerMapper.ToEntity(computer));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            var existingComputer = _context.Computers.Find(id);
            if (existingComputer != null)
            {
                _context.Computers.Remove(existingComputer);
                _context.SaveChanges();
            }
        }
        public void Update(Computer computer)           //Computer - ID , Name, Processor, Memory, GraphicsCard, Manufacturer, ProductionDate, 
        {
            var existingComputer = _context.Computers.Find(computer.Id);
            if (existingComputer != null)
            {
                existingComputer.Name = computer.Name;
                existingComputer.Processor = computer.Processor;
                existingComputer.Memory = computer.Memory;
                existingComputer.GraphicsCard = computer.GraphicsCard;
                existingComputer.Manufacturer = computer.Manufacturer;
                existingComputer.ProductionDate = computer.ProductionDate;

                _context.SaveChanges();
            }
        }
        public List<Computer> Find()
        {
            return _context.Computers.Select(e => ComputerMapper.FromEntity(e)).ToList(); ;
        }

        public Computer? FindComputerById(int id)
        {
            return ComputerMapper.FromEntity(_context.Computers.Find(id));
        }



        public List<ProducerEntity> FindAllProducents()
        {
            return _context.Producers.ToList();
        }
    }
}
