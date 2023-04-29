using Concierto.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Shared.Entities
{
    public class Tickets
    {
        public int Id { get; set; }
        public DateTime? UseDate { get; set; } = null;
        public bool IsUsed { get; set; }

        public EntryDoor? Door { get; set; } = null;
    }
}
