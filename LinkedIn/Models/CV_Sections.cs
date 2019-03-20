namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CV_Sections
    {
        [Key]
        public int cv_section_id { get; set; }

        public int? cv_id { get; set; }

        public int? cv_section_code { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_created { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_updated { get; set; }

        public string cv_section_text { get; set; }

        public virtual CV CV { get; set; }

        public virtual Ref_CV_Sections Ref_CV_Sections { get; set; }
    }
}
