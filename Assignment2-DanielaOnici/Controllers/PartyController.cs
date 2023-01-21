using Assignment2_DanielaOnici.Entities;
using Assignment2_DanielaOnici.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace Assignment2_DanielaOnici.Controllers
{
    public class PartyController : Controller
    {

        private PartyDBContext _partyDBContext;

        public PartyController(PartyDBContext partyDBContext)
        {
            _partyDBContext = partyDBContext;
        }

        [HttpGet("/parties")]
        public IActionResult GetAllParties()
        {
            // Access all the parties in DB and order by date
            var parties = _partyDBContext.Parties.Include(p => p.Invitations)
                    .OrderBy(pt => pt.EventDate).ToList();

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

            return View("Parties", parties);
        }

        [HttpGet("/parties/{id}")]
        public IActionResult GetPartyById(int id)
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

            // Look for the party by ID inside the DB, including the invitations
            var party = _partyDBContext.Parties
                .Include(p => p.Invitations)
                .Where(p => p.PartyId == id).FirstOrDefault();

            ManagePartyViewModel managePartyViewModel = new ManagePartyViewModel()
            {
                ActiveParty = party
            };
            return View("Manage", managePartyViewModel);
        }

        [HttpGet("/parties/add-request")]
        public IActionResult GetAddPartyRequest()
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

            return View("Add", new Party());
        }

        [HttpPost("/parties")]
        public IActionResult AddNewParty(Party party)
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

            // If the input is valid a new party is added to the DB
            if (ModelState.IsValid)
            {
                _partyDBContext.Parties.Add(party);
                _partyDBContext.SaveChanges();

                // Set a last action msg:
                TempData["LastActionMessage"] = $"The party was added successfully.";

                // Redirect to parties page
                return RedirectToAction("GetAllParties", "Party");
            }
            else
            {
                // Return the Add page with the errors
                return View("Add", party);
            }
        }


        [HttpGet("/parties/{id}/edit-request")]
        public IActionResult GetEditPartyRequestById(int id)
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

            PartyViewModel partyViewModel = new PartyViewModel()
            {
                ActiveParty = _partyDBContext.Parties.Find(id)
            };

            return View("Edit", partyViewModel);
        }

        [HttpPost("/parties/{id}/edit-requests")]
        public IActionResult ProcessEditPartyRequest(int id, PartyViewModel partyViewModel)
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

            // Verifies if the id from URL is equal to the one passed in the POST
            if (id != partyViewModel.ActiveParty.PartyId)
                return NotFound();

            // When the input is valid the party is updated
            if (ModelState.IsValid)
            {
                _partyDBContext.Parties.Update(partyViewModel.ActiveParty);
                _partyDBContext.SaveChanges();

                // Set a last action msg:
                TempData["LastActionMessage"] = $"The party was updated successfully.";

                return RedirectToAction("GetAllParties", "Party");
            }
            else
            {
                // Return to the edit page with the errors
                return View("Edit", partyViewModel);
            }
        }

        [HttpPost("/parties/{id}/invitations")]
        public IActionResult AddInvitationToPartyById(int id, ManagePartyViewModel managePartyViewModel)
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

            // Gets the party and its invitations from id
            var party = _partyDBContext.Parties
                        .Include(p => p.Invitations)
                        .Where(p => p.PartyId == id)
                        .FirstOrDefault();

            if (ModelState.IsValid)
            {
                // Gets the new invitation and add it to the list of invitations
                party.Invitations.Add(managePartyViewModel.NewInvitation);
                _partyDBContext.SaveChanges();

                // Set a last action msg:
                TempData["LastActionMessage"] = $"The invitation was created successfully.";

                // Redirect back to the same page passing the ID to the URL
                return RedirectToAction("GetPartyById", "Party", new { id = id });
            }
            else
            {
                managePartyViewModel = new ManagePartyViewModel()
                {
                    ActiveParty = party
                };

                return View("Manage", managePartyViewModel);
            }

        }

        [HttpPost("/parties/{id}/send-invitations-requests")]
        public IActionResult SendInvitationsByPartyId(int id)
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

            // retrieve the whole movie:
            var party = _partyDBContext.Parties
                    .Include(p => p.Invitations)
                    .Where(p => p.PartyId == id)
                    .FirstOrDefault();

            if(party.Invitations == null)
            {
                TempData["LastActionMessage"] = $"There is no invitation to be sent. Please, create one!";
            }

            foreach(var invite in party.Invitations)
            {
                if(invite.Status == InvitationStatus.InvitationNotSent)
                {

                    string fromAddress = "danielaonici@gmail.com";
                    string toAddress = invite.Email;
                    string url = $"https://localhost:7173/invitation/{invite.InvitationId}/response-request";

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromAddress, "ocfciixheaxpceba"),
                        EnableSsl = true,
                    };

                    var mailMessage = new MailMessage()
                    {
                        From = new MailAddress(fromAddress),
                        Subject = $"You have been invited to the {invite.Party.Description}",
                        Body = $"<h1>Hello, {invite.GuestName}:</h1><p>You have been invited to the {invite.Party.Description} at {invite.Party.Location} on {invite.Party.EventDate?.ToString("d")}!!</p><p>We would be thrilled to have you so please <a href=\"{url}\">let us know</a> if you can as soon as possible!</p>" +
                        $"<p>Sincerely,</p>" +
                        $"<p>The Party Manager App</p>",
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(toAddress);

                    smtpClient.Send(mailMessage);

                    invite.Status = InvitationStatus.InvitationSent;

                    _partyDBContext.Invitations.Update(invite);
                    _partyDBContext.SaveChanges();

                    // Set a last action msg:
                    TempData["LastActionMessage"] = $"Invitations sent!";
                }
                else
                {
                    // If no invitaiton is 
                    TempData["LastActionMessage"] = $"All invitations were already sent. Please, create one!";
                }
            }

            // redirect back to the same details view pasing the ID to the URL:
            return RedirectToAction("GetPartyById", "Party", new { id = id });
        }

    }
}
