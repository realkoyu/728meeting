﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _728Meeting.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RecordEntities : DbContext
    {
        public RecordEntities()
            : base("name=RecordEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ParticipantEvent> ParticipantEvent { get; set; }
    }
}
