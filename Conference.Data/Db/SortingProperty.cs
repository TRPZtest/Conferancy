namespace Conferency.Data.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SortingProperty
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }

        public bool IsDescending { get; set; }
    }
}
