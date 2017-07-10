namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.ModelBinding;

    [Table("Support")]
    public partial class Support
    {
        public int id { get; set; }

        [DisplayName("Cliente")]
        public int id_cliente { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Título")]
        public string titulo { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Detalle")]
        public string detalle { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Estado")]
        public string estado { get; set; }

        public enum listEstado
        {
            Abierto,
            Proceso,
            Espera,
            Finalizado
        }
        [DisplayName("Usuario")]
        [Required]
        public int id_user { get; set; }

        public IEnumerable<Cliente> listCliente;

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
       
}
