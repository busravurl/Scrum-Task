﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrelloKubra.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbTrelloEntities : DbContext
    {
        public dbTrelloEntities()
            : base("name=dbTrelloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Durum> tbl_Durum { get; set; }
        public virtual DbSet<tbl_GorevDurumlari> tbl_GorevDurumlari { get; set; }
        public virtual DbSet<tbl_Gorevler> tbl_Gorevler { get; set; }
        public virtual DbSet<tbl_Kullanicilar> tbl_Kullanicilar { get; set; }
    }
}