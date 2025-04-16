using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recochapp.Shared.Entities
{
    public class PlanDestination
    {
        public int Id { get; set; }
        public int PlanDestinationId { get; set; }


        public Establishment? Establishment { get; set; }
        public int? EstablishmentId { get; set; }


        public Place? Place { get; set; }
        public int? PlaceId { get; set; }


    }
}
