namespace LinkedIn.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LinkedInContext : DbContext
    {
        public LinkedInContext()
            : base("name=LinkedInContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<CV_Sections> CV_Sections { get; set; }
        public virtual DbSet<CV> CVs { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Members_Groups> Members_Groups { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<People_Being_Followed> People_Being_Followed { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<Ref_CV_Sections> Ref_CV_Sections { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.line_1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.line_2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.line_3)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.state_country_province)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.zip_or_postcode)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<CV_Sections>()
                .Property(e => e.cv_section_text)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.group_name)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.group_description)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Members_Groups)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.marital_status_description)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.email_address)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.email_password)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.middle_name)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Connections)
                .WithOptional(e => e.Member)
                .HasForeignKey(e => e.member_id);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Connections1)
                .WithOptional(e => e.Member1)
                .HasForeignKey(e => e.connection_member_id);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.Member)
                .HasForeignKey(e => e.created_by_member_id);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Members_Groups)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.messages)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_sender_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.messages1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.member_receiver_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.People_Being_Followed)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.People_Being_Followed1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.member_being_followed_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Recommendations)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.member_recommending_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Recommendations1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.member_being_recommended_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.organization_name)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.organization_description)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Members)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.current_organization_id);

            modelBuilder.Entity<People_Being_Followed>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recommendation>()
                .Property(e => e.other_details)
                .IsUnicode(false);

            modelBuilder.Entity<Ref_CV_Sections>()
                .Property(e => e.cv_section_description)
                .IsUnicode(false);
        }
    }
}
