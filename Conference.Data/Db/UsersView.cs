namespace Conferency.Data.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersView")]
    public partial class UsersView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(101)]
        public string FullName { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
