namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contacto")]
    public partial class Contacto
    {
        public int id { get; set; }

        [DisplayName("Cliente")]
        public int id_cliente { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Apellido")]
        public string apellido { get; set; }

        [Required]
        [StringLength(20), EmailAddress]
        [DisplayName("E-mail")]
        public string correo { get; set; }

        [DisplayName("Teléfono")]
        [Required]
        public int telefono { get; set; }

        [DisplayName("Puesto")]
        [StringLength(20)]
        [Required]
        public string puesto { get; set; }

        public IEnumerable<Cliente> listClientes;
        public virtual Cliente Cliente { get; set; }
    }
}
