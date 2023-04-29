using Concierto.Shared.Entities;

namespace Concierto.API.Data
{

    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;      
      
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Tickets.Any())
            {
              for(int i =  1; i <= 50000; i++)
                {
                    _context.Tickets.Add( new Tickets { IsUsed = false});

                }
            }

            await _context.SaveChangesAsync();
        }


    }
}
