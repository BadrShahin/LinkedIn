namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        [Key]
        public int id { get; set; }

        public int? member_id { get; set; }

        public int? cv_section_id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50)]
        public string school_name { get; set; }

        [Required(ErrorMessage ="Location is required")]
        [StringLength(50)]
        public string school_location { get; set; }

        [Required(ErrorMessage ="Start Date is required")]
        [Column(TypeName = "date")]
        public DateTime? start_date { get; set; }

        [Required(ErrorMessage ="End Date is required")]
        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }

        public string other_details { get; set; }

        public virtual CV_Sections CV_Sections { get; set; }

        public virtual Member Member { get; set; }
    }
}
