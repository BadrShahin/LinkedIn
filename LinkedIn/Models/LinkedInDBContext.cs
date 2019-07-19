namespace LinkedIn.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LinkedInDBContext : DbContext
    {
        public LinkedInDBContext()
            : base("name=LinkedInDBContext")
        {
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<CV_Sections> CV_Sections { get; set; }
        public virtual DbSet<CV> CVs { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Members_Groups> Members_Groups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<People_Being_Followed> People_Being_Followed { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<Ref_CV_Sections> Ref_CV_Sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Experience>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Connections)
                .WithOptional(e => e.Member)
                .HasForeignKey(e => e.connection_member_id);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Connections1)
                .WithOptional(e => e.Member1)
                .HasForeignKey(e => e.member_id);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.Member)
                .HasForeignKey(e => e.Member_member_id);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_receiver_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.member_sender_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.People_Being_Followed)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_being_followed_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.People_Being_Followed1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.member_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Recommendations)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_being_recommended_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Recommendations1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.member_recommending_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Members)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.Organization_organization_id);
        }
    }
    
}