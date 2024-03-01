using Data.Entities;
using Lab_ASPNET.Models;

namespace Lab_ASPNET.Services.Producery
{
    public interface IProducerService
    {
        int Add(Producer producer);
        void Delete(int id);
        void Update(Producer producer);
        List<Producer> Find();
        Producer? FindProducerById(int id);
        List<ProducerEntity> FindAllProducents();

    }
}
