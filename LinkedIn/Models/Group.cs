namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            Members_Groups = new HashSet<Members_Groups>();
        }

        [Key]
        public int group_id { get; set; }

        public int? created_by_member_id { get; set; }

        [StringLength(50)]
        public string group_name { get; set; }

        [StringLength(50)]
        public string group_description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? group_date_started { get; set; }

        [Column(TypeName = "date")]
        public DateTime? group_date_ended { get; set; }

        [Column(TypeName = "date")]
        public DateTime? group_date_last_activity { get; set; }

        public string other_details { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Members_Groups> Members_Groups { get; set; }
    }
}
