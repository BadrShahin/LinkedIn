namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Addresses = new HashSet<Address>();
            Comments = new HashSet<Comment>();
            Connections = new HashSet<Connection>();
            Connections1 = new HashSet<Connection>();
            CVs = new HashSet<CV>();
            Educations = new HashSet<Education>();
            Experiences = new HashSet<Experience>();
            Groups = new HashSet<Group>();
            Members_Groups = new HashSet<Members_Groups>();
            Messages = new HashSet<Message>();
            Messages1 = new HashSet<Message>();
            People_Being_Followed = new HashSet<People_Being_Followed>();
            People_Being_Followed1 = new HashSet<People_Being_Followed>();
            Posts = new HashSet<Post>();
            Recommendations = new HashSet<Recommendation>();
            Recommendations1 = new HashSet<Recommendation>();
        }

        [Key]
        public int member_id { get; set; }

        public int? current_organization_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Marital Status")]
        public string marital_status_description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_joined { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? date_of_birth { get; set; }

        [Required(ErrorMessage = "Enter Your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string email_address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string email_password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter Your First Name")]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [StringLength(50)]
        public string middle_name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter your last Name")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [StringLength(50)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Other Details")]
        public string other_details { get; set; }

        public string profile_image { get; set; }

        public int? Organization_organization_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connection> Connections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connection> Connections1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CV> CVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experience> Experiences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Members_Groups> Members_Groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<People_Being_Followed> People_Being_Followed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<People_Being_Followed> People_Being_Followed1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommendation> Recommendations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recommendation> Recommendations1 { get; set; }
    }
}
