﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public object Entry<T>()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<division_mst> division_mst { get; set; }
        public virtual DbSet<prison_mst> prison_mst { get; set; }
        public virtual DbSet<code_mst> code_mst { get; set; }
    }
}
