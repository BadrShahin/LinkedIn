namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Members = new HashSet<Member>();
        }

        [Key]
        public int Address_id { get; set; }

        [StringLength(50)]
        public string line_1 { get; set; }

        [StringLength(50)]
        public string line_2 { get; set; }

        [StringLength(50)]
        public string line_3 { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string state_country_province { get; set; }

        [StringLength(50)]
        public string zip_or_postcode { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string other_details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
