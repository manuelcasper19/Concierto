using Concierto.API.Data;
using Concierto.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Concierto.API.Controllers
{
    [ApiController]
    [Route("/api/tickets")]

    public class ControllerTickets: ControllerBase
    {
        private readonly DataContext _context;

        public ControllerTickets(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Tickets.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                var ticket = await _context.Tickets
                  .FirstOrDefaultAsync(c => c.Id == id);
                if (ticket == null)
                {
                    return BadRequest( "Boleta no válida");
                }

                if (ticket!.IsUsed)
                {
                    return BadRequest( $"La boleta ya fue usada el {ticket.UseDate} en la puerta {ticket.Door}");
                }
              
                return Ok(ticket);
            }

            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> PutAsync(Tickets ticket)
        {
            try
            {
                _context.Update(ticket);
                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
 
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        private async Task<string> validateTicket( int id)
        {
            var ticket = await _context.Tickets
               .FirstOrDefaultAsync(c => c.Id == id);
            if (ticket == null)
            {
                return "Boleta no válida";
            }

            if (ticket!.IsUsed)
            {
                return $"La boleta ya fue usada el {ticket.UseDate} en la puerta {ticket.Door}";
            }
            return "";
        }

    }
}
