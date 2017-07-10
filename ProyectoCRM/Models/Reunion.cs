namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reunion")]
    public partial class Reunion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reunion()
        {
            Reunion_user = new HashSet<Reunion_user>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string titulo { get; set; }

        public DateTime fecha { get; set; }

        [Column("virtual")]
        public bool _virtual { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reunion_user> Reunion_user { get; set; }
    }
}
