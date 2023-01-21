using Assignment2_DanielaOnici.Entities;
using Microsoft.VisualBasic;

namespace Assignment2_DanielaOnici.Models
{
    public class ManagePartyViewModel
    {
        public Party? ActiveParty { get; set; }

        public Invitation? NewInvitation { get; set; }

        public int NotSentCount 
        { 
            get
            {
                int result = 0;

                if(ActiveParty?.Invitations.Count > 0)
                {
                    foreach (var invitation in ActiveParty?.Invitations)
                    {
                        if (invitation.Status == InvitationStatus.InvitationNotSent)
                        {
                            result++;
                        }
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        public int SentCount
        {
            get
            {
                int result = 0;

                if (ActiveParty?.Invitations.Count > 0)
                {
                    foreach (var invitation in ActiveParty?.Invitations)
                    {
                        if (invitation.Status == InvitationStatus.InvitationSent)
                        {
                            result++;
                        }
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }
        public int YesCount 
        {
            get
            {
                int result = 0;

                if (ActiveParty?.Invitations.Count > 0)
                {
                    foreach (var invitation in ActiveParty?.Invitations)
                    {
                        if (invitation.Status == InvitationStatus.RespondedYes)
                        {
                            result++;
                        }
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        public int NoCount 
        {
            get
            {
                int result = 0;

                if (ActiveParty?.Invitations.Count > 0)
                {
                    foreach (var invitation in ActiveParty?.Invitations)
                    {
                        if (invitation.Status == InvitationStatus.RespondedNo)
                        {
                            result++;
                        }
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }
    }
}
