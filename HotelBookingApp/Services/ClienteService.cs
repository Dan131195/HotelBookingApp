
using HotelBookingApp.Models;
using HotelBookingApp.Data;

namespace HotelBookingApp.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAllClients() => _context.Clienti.ToList();

        public Cliente GetClienteById(Guid id) => _context.Clienti.Find(id);

        public void CreateCliente(Cliente cliente)
        {
            _context.Clienti.Add(cliente);
            _context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _context.Clienti.Update(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(Guid id)
        {
            var cliente = _context.Clienti.Find(id);
            if (cliente != null)
            {
                _context.Clienti.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
