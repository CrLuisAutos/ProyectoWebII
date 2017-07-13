namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reunion")]
    public partial class Reunion
    {

        public int id { get; set; }
        public int id_user { get; set; }
        public int id_cliente { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Título")]
        public string titulo { get; set; }

        [DisplayName("Fecha")]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode =true)]
        public DateTime fecha { get; set; }

        [DisplayName("¿Es virtual?")]
        [Column("virtual")]
        public bool _virtual { get; set; }

        public ICollection<Cliente> ListCliente;

        public ICollection<AspNetUsers> ListUsuario;

        public virtual Cliente cliente { get; set; }
        public virtual AspNetUsers usuarios { get; set; }

    }
}
