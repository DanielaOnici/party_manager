using System.ComponentModel.DataAnnotations;

namespace Assignment2_DanielaOnici.Entities
{
    public class Party
    {
        public int PartyId { get; set; }


        [Required(ErrorMessage = "Please, insert a description.")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Please, insert the date of the event.")]
        public DateTime? EventDate { get; set; }


        public string? Location { get; set; }


        public List<Invitation>? Invitations { get; set; }


        public int? NumberOfInvites
        {
            get
            {
                return Invitations?.Count;
            }
        }

    }
}
