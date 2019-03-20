namespace LinkedIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Connection
    {
        [Key]
        public int connection_id { get; set; }

        public int? connection_member_id { get; set; }

        public int? member_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_connection_made { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member Member1 { get; set; }
    }
}
