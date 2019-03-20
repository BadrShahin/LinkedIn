namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CV()
        {
            CV_Sections = new HashSet<CV_Sections>();
        }

        [Key]
        public int cv_id { get; set; }

        public int? member_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_created { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_updated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CV_Sections> CV_Sections { get; set; }

        public virtual Member Member { get; set; }
    }
}
