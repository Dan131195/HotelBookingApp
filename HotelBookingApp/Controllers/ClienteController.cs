using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelBookingApp.Models;
using HotelBookingApp.Services;

namespace HotelBookingApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index() => View(_clienteService.GetAllClients());

        public IActionResult Details(Guid id)
        {
            var cliente = _clienteService.GetClienteById(id);
            return cliente == null ? NotFound() : View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Crea")]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.ClienteId = Guid.NewGuid();
                _clienteService.CreateCliente(cliente);
                return RedirectToAction(("Index"));
            }
            return View(cliente);
        }

        public IActionResult Edit(Guid id)
        {
            var cliente = _clienteService.GetClienteById(id);
            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Cliente cliente)
        {
            if (id != cliente.ClienteId) return NotFound();

            if (ModelState.IsValid)
            {
                _clienteService.UpdateCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(Guid id)
        {
            var cliente = _clienteService.GetClienteById(id);
            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _clienteService.DeleteCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
