using Assignment2_DanielaOnici.Entities;
using Assignment2_DanielaOnici.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_DanielaOnici.Controllers
{
    public class ResponseController : Controller
    {
        private PartyDBContext _partyDBContext;

        public ResponseController(PartyDBContext partyDBContext)
        {
            _partyDBContext = partyDBContext;
        }

        [HttpGet("invitation/{invitationId}/response-request")]
        public IActionResult GetInvitationById(int invitationId)
        {
            // Check if the cookie already exists.If so, read it.
            if (Request.Cookies.ContainsKey("timeVisit"))
            {
                string time = Request.Cookies["timeVisit"];
                ViewBag.TimeVisit = $"Welcome Back! Your first visit was at {time}";
            }
            // if not, create one with the date time
            else
            {
                DateTime timeVisit = DateTime.Now;
                string time = timeVisit.ToString("g");

                Response.Cookies.Append("timeVisit", time);
                ViewBag.TimeVisit = "Welcome to the Party Guest Manager App!";
            }

            // Retrieve the new invitation sent according to the ID in DB
            ManagePartyViewModel managePartyViewModel = new ManagePartyViewModel()
            {
                NewInvitation = _partyDBContext.Invitations
                .Include(p => p.Party)
                .Where(p => p.InvitationId == invitationId).FirstOrDefault()
            };

            // return to the invitation page with invitation's info
            return View("Invitation", managePartyViewModel);
        }


        [HttpPost("invitation/response-requests")]
        public IActionResult ProcessResponseToTheInvitation(int id, ManagePartyViewModel managePartyViewModel)
        {
            // Check if the cookie already exists.If so, read it.
            if (Request.Cookies.ContainsKey("timeVisit"))
            {
                string time = Request.Cookies["timeVisit"];
                ViewBag.TimeVisit = $"Welcome Back! Your first visit was at {time}";
            }
            // if not, create one with the date time
            else
            {
                DateTime timeVisit = DateTime.Now;
                string time = timeVisit.ToString("g");

                Response.Cookies.Append("timeVisit", time);
                ViewBag.TimeVisit = "Welcome to the Party Guest Manager App!";
            }

                _partyDBContext.Invitations.Update(managePartyViewModel.NewInvitation);
                _partyDBContext.SaveChanges();

            if(managePartyViewModel.NewInvitation.Status == InvitationStatus.RespondedYes)
            {
                return View("Yes");
            }
            else
            {
                return View("No");

            } 
        }
    }
}
