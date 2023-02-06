using Microsoft.EntityFrameworkCore;
using Server.Entity;

namespace Server.Contexts
{
    public partial class CleanerDBContext : DbContext
    {

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<User_Types> User_Types { get; set; }
        public virtual DbSet<User_Roles> User_Roles { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Transaction_Types> Transaction_Types { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Quiz_Choice> Quiz_Choices { get; set; }
        public virtual DbSet<Package_types> Package_types { get; set; }
        public virtual DbSet<Login_Types> Login_Types { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<General_info> General_info { get; set; }
        public virtual DbSet<General_info_answer> General_info_answer { get; set; }
        public virtual DbSet<Cleaning_type> Cleaning_type { get; set; }
        public virtual DbSet<Cleaning_details> Cleaning_details { get; set; }
        public virtual DbSet<Background_check> Background_check { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Star_rate_detail> Star_rate_details { get; set; }
        // public virtual DbSet<Star_rate_type> Star_rate_types { get; set; }
        public virtual DbSet<Agent_rate> Agent_rate { get; set; }

        public virtual DbSet<Agent_Users> Agent_Users { get; set; }
        public virtual DbSet<User_quiz_answer> User_Quiz_Answers { get; set; }
        public CleanerDBContext(DbContextOptions<CleanerDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<Users>(e =>
            {
                e.ToTable("users")
                .HasKey(k => k.Id);

                e
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuider.Entity<Agent_rate>()
            .HasKey(c => c.Id);
            modelBuider.Entity<Agent_rate>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();

            modelBuider.Entity<Cleaning_type>()
            .HasKey(c => c.Id);
            modelBuider.Entity<Cleaning_type>()
                .Property(p => p.Id)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .ValueGeneratedOnAdd();


            //     modelBuider.Entity<Quiz>()
            //    .HasMany(p => p.Quiz_Choices)
            //    .WithOne(x => x.Quiz)
            //    .HasForeignKey(x => x.quiz_id);




            base.OnModelCreating(modelBuider);
        }



    }
}