using MicroApi.Models;

namespace MicroApi.Services
{
    public class ClientService
    {
        private readonly List<Client> _clients = new();
        private int _idCurrent = 1;

        public List<Client> GetAll() => _clients;
        public Client GetById(int id) => _clients.FirstOrDefault(c => c.Id == id);
        public Client Create(Client client)
        {
            client.Id = _idCurrent++;
            _clients.Add(client);
            return client;
        }
    }
}
