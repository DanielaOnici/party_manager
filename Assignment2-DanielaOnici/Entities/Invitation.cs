using System.ComponentModel.DataAnnotations;

namespace Assignment2_DanielaOnici.Entities
{
    public enum InvitationStatus { 
        InvitationNotSent,
        InvitationSent,
        RespondedYes,
        RespondedNo }

    public class Invitation
    {
        public int InvitationId { get; set; }


        [Required(ErrorMessage = "Please, insert the name of the guest.")]
        public string? GuestName { get; set; }


        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please, insert a valid email")]
        [Required(ErrorMessage = "Please, insert an email address.")]
        public string? Email { get; set; }


        public InvitationStatus Status { get; set; } = InvitationStatus.InvitationNotSent;


        public int? PartyId { get; set; }


        public Party? Party { get; set; }
    }
}
