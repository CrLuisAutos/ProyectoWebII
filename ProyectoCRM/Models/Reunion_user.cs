namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reunion_user
    {
        public int id { get; set; }

        public int id_user { get; set; }

        public int id_reunion { get; set; }

        public int? id_cliente { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Reunion Reunion { get; set; }
    }
}
