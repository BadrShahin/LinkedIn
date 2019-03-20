namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members_Groups
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int member_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int group_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_joined { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_left { get; set; }

        public virtual Group Group { get; set; }

        public virtual Member Member { get; set; }
    }
}
