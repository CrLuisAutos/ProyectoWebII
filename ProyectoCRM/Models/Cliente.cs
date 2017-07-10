namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Contacto = new HashSet<Contacto>();
            Support = new HashSet<Support>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [Required]
        [DisplayName("Cédula Jurídica")]
        [Range(10000000, 99999999999,ErrorMessage ="Logitud mínima de la cédula jurídica es de 8")]
        public int cedula { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Página Web")]
        public string pagina_web { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Dirección")]
        public string direccion { get; set; }

        [Required]
        [DisplayName("Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int telefono { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Sector")]
        public string sector { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contacto> Contacto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reunion> Reunion_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Support> Support { get; set; }
    }
}
