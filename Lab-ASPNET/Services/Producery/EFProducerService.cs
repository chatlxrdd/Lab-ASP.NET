using System.Diagnostics;
using System;
using Lab_ASPNET.Models;
using Lab_ASPNET.Mappers;
using Data;
using Data.Entities;

namespace Lab_ASPNET.Services.Producery
{
    public class EFProducerService : IProducerService
    {
        private AppDbContext _context;
        public EFProducerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Producer producer)
        {
            var e = _context.Producers.Add(ProducerMapper.ToEntity(producer));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            var existingProducer = _context.Producers.Find(id);
            if (existingProducer != null)
            {
                _context.Producers.Remove(existingProducer);
                _context.SaveChanges();
            }
        }
        public void Update(Producer producer)
        {
            var existingProducer = _context.Producers.Find(producer.Id);
            if (existingProducer != null)
            {               // Title Regon Nip Company
                existingProducer.Title = producer.Title;
                existingProducer.Regon = producer.Regon;
                existingProducer.Nip = producer.Nip;

                _context.SaveChanges();
            }
        }
        public List<Producer> Find()
        {
            return _context.Producers.Select(e => ProducerMapper.FromEntity(e)).ToList(); ;
        }

        public Producer? FindProducerById(int id)
        {
            return ProducerMapper.FromEntity(_context.Producers.Find(id));
        }
        public List<ProducerEntity> FindAllProducents()
        {
            return _context.Producers.ToList();
        }
    }
}
