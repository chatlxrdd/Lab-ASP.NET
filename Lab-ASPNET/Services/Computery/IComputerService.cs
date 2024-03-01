using Lab_ASPNET.Models;
using System.Diagnostics;
using Data.Entities;

namespace Lab_ASPNET.Services.Computery
{
    public interface IComputerService
    {
        int Add(Computer computer);
        void Delete(int id);
        void Update(Computer computer);
        List<Computer> Find();
        Computer? FindComputerById(int id);
        List<ProducerEntity> FindAllProducents();
    }
}
