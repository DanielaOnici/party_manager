using Assignment2_DanielaOnici.Entities;
using Microsoft.VisualBasic;

namespace Assignment2_DanielaOnici.Models
{
    public class PartyViewModel
    {
        public Party? ActiveParty { get; set; }

        public List<Invitation>? Invitations { get; set; }
    }
}
