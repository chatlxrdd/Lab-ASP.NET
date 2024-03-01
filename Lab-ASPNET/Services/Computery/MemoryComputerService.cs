using Data.Entities;
using Lab_ASPNET.Models;
using System.Diagnostics;

namespace Lab_ASPNET.Services.Computery
{
    public class MemoryComputerService : IComputerService
    {
        private Dictionary<int, Computer> _items = new Dictionary<int, Computer>();

        public int Add(Computer item)
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

        public List<Computer> Find()
        {
            return _items.Values.ToList();
        }

        public Computer? FindComputerById(int id)
        {
            return _items.ContainsKey(id) ? _items[id] : null;
        }

        public void Update(Computer computer)
        {
            if (_items.ContainsKey(computer.Id))
            {
                _items[computer.Id] = computer;
            }
        }

        public List<ProducerEntity> FindAllProducents()
        {
            return new List<ProducerEntity>();
        }
    }
}

