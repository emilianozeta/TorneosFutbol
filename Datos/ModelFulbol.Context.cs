﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class futbolEntities : DbContext
    {
        public futbolEntities()
            : base("name=futbolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<contacto> contacto { get; set; }
        public virtual DbSet<equipo> equipo { get; set; }
        public virtual DbSet<genero> genero { get; set; }
        public virtual DbSet<jugador> jugador { get; set; }
        public virtual DbSet<localidad> localidad { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }
        public virtual DbSet<torneo> torneo { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
