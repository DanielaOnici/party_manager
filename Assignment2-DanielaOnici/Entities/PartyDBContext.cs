using Microsoft.EntityFrameworkCore;

namespace Assignment2_DanielaOnici.Entities
{
    public class PartyDBContext : DbContext
    {
        public PartyDBContext(DbContextOptions<PartyDBContext> options) : base(options)
        {
        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Party>().HasData(
                new Party()
                {
                    PartyId = 1,
                    Description = "New year's eve blast!!",
                    EventDate = Convert.ToDateTime("2022/12/31 12:00"),
                    Location = "Times Square, NY"
                },
                new Party() { 
                    PartyId = 2,
                    Description = "Drinks at Moe's Bar", 
                    EventDate = Convert.ToDateTime("2022/10/30 04:43"), 
                    Location = "Moe's Bar, Springfield" 
                },
                new Party() { 
                    PartyId = 3, 
                    Description = "Thanksgiving gathering", 
                    EventDate = Convert.ToDateTime("2022/10/20 04:43"), 
                    Location = "Springfield" });

            modelBuilder.Entity<Invitation>()
                .Property(inv => inv.Status)
                .HasConversion<string>()
                .HasMaxLength(64);

            modelBuilder.Entity<Invitation>().HasData(
                new Invitation()
                {
                    InvitationId = 1,
                    GuestName = "Daniela Onici",
                    Email = "danielaonici@gmail.com",
                    Status = InvitationStatus.InvitationSent,
                    PartyId = 1
                },
                new Invitation()
                {
                    InvitationId = 2,
                    GuestName = "Gloria",
                    Email = "gloria@gmail.com",
                    Status = InvitationStatus.RespondedNo,
                    PartyId = 1
                },
                new Invitation()
                {
                    InvitationId = 3,
                    GuestName = "Boa",
                    Email = "boa@gmail.com",
                    Status = InvitationStatus.InvitationNotSent,
                    PartyId = 1
                },
                new Invitation()
                {
                    InvitationId = 4,
                    GuestName = "Gabriela",
                    Email = "gabriela@gmail.com",
                    Status = InvitationStatus.RespondedYes,
                    PartyId = 1
                },
                new Invitation()
                {
                    InvitationId = 5,
                    GuestName = "Luiz",
                    Email = "luiz@gmail.com",
                    Status = InvitationStatus.InvitationSent,
                    PartyId = 2
                },
                new Invitation()
                {
                    InvitationId = 6,
                    GuestName = "Daniela Onici",
                    Email = "danielaonici@gmail.com",
                    Status = InvitationStatus.InvitationSent,
                    PartyId = 3
                });

        }
    }
}
