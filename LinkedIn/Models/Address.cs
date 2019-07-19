namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        [Key]
        public int Address_id { get; set; }

        public int? member_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Street")]
        public string line_1 { get; set; }

        [StringLength(50)]
        public string line_2 { get; set; }

        [StringLength(50)]
        public string line_3 { get; set; }

        [Required(ErrorMessage ="City is required")]
        [StringLength(50)]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage ="State is required")]
        [StringLength(50)]
        public string state_country_province { get; set; }

        [StringLength(50)]
        public string zip_or_postcode { get; set; }

        [Required(ErrorMessage ="Country is required")]
        [StringLength(50)]
        [Display(Name = "Country")]
        public string country { get; set; }

        [StringLength(50)]
        [Display(Name = "Other Details")]
        public string other_details { get; set; }

        public virtual Member Member { get; set; }
    }
}
