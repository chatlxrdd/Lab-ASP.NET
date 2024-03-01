using Data.Entities;
using Lab_ASPNET.Models;

namespace Lab_ASPNET.Services.Producery
{
    public class MemoryProducerService : IProducerService
    {
        private Dictionary<int, Producer> _items = new Dictionary<int, Producer>();

        public int Add(Producer item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Producer> Find()
        {
            return _items.Values.ToList();
        }

        public Producer? FindProducerById(int id)
        {
            return _items.ContainsKey(id) ? _items[id] : null;
        }

        public void Update(Producer producer)
        {
            if (_items.ContainsKey(producer.Id))
            {
                _items[producer.Id] = producer;
            }
        }

        public List<ProducerEntity> FindAllProducents()
        {
            return new List<ProducerEntity>();
        }
    }
}
