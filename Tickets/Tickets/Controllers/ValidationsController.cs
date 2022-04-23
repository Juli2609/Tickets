using Microsoft.AspNetCore.Mvc;
using Tickets.Data;
using Tickets.Data.Entities;
using Tickets.Helpers;
using Tickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tickets.Controllers
{
    public class ValidationsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ValidationsController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        public IActionResult CheckTicket()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckTicket(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            Ticket ticket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.Id == id);

            if (id < 0 || id > 5003)
            {
                TempData["Message"] = "Error de boleta, no existe";

                return RedirectToAction(nameof(CheckTicket));

            }

            if (ticket.WasUsed != false)
            {
                TempData["Message"] = "Ticket ya es usado.";
                TempData["Name"] = ticket.Name;
                TempData["Document"] = ticket.Document;
                TempData["Date"] = ticket.Date;
                //TODO : time and entrance
                return RedirectToAction(nameof(CheckTicket), new { Id = ticket.Id });
            }
            else
            {
                TempData["Message"] = "Ticket no ha sido usada.";
                return RedirectToAction(nameof(Register), new { Id = ticket.Id });
            }

        }

        private object Register()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DetailTicket(int? id)

        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
    }
}






