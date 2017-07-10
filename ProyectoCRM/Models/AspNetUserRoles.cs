namespace ProyectoCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserRoles
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }

        public int Id { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
