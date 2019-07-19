namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experience")]
    public partial class Experience
    {
        [Key]
        public int experience_id { get; set; }

        public int? member_id { get; set; }

        public int? cv_section_id { get; set; }

        [Required(ErrorMessage ="Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage ="Company Name is required")]
        public string company_name { get; set; }

        [Required(ErrorMessage ="Company Location is required")]
        public string company_location { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Required(ErrorMessage ="Start Date is required")]
        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Required(ErrorMessage ="End Date is required")]
        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        [Column(TypeName = "text")]
        public string other_details { get; set; }

        public virtual CV_Sections CV_Sections { get; set; }

        public virtual Member Member { get; set; }
    }
}
