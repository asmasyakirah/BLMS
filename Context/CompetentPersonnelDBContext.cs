using System;
using BLMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BLMS.Context
{
    public partial class CompetentPersonnelDBContext : DbContext
    {
        public CompetentPersonnelDBContext()
        {
        }

        public CompetentPersonnelDBContext(DbContextOptions<CompetentPersonnelDBContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Example> Examples { get; set; }
        //public virtual DbSet<ExcelCategory> ExcelCategories { get; set; }
        //public virtual DbSet<ExcelCorporateOffice> ExcelCorporateOffices { get; set; }
        //public virtual DbSet<ExcelInfraEpb> ExcelInfraEpbs { get; set; }
        //public virtual DbSet<ExcelInfraEpb1> ExcelInfraEpb1s { get; set; }
        //public virtual DbSet<ExcelInfraEpb2> ExcelInfraEpb2s { get; set; }
        //public virtual DbSet<ExcelLink> ExcelLinks { get; set; }
        //public virtual DbSet<TblAuditLog> TblAuditLogs { get; set; }
        //public virtual DbSet<TblAuthorityLink> TblAuthorityLinks { get; set; }
        //public virtual DbSet<TblBusinessDiv> TblBusinessDivs { get; set; }
        //public virtual DbSet<TblBusinessUnit> TblBusinessUnits { get; set; }
        //public virtual DbSet<TblCategory> TblCategories { get; set; }
        //public virtual DbSet<TblCertBody> TblCertBodies { get; set; }
        public virtual DbSet<CompetentPersonnel> CompetentPersonnel { get; set; }
        //public virtual DbSet<TblErrorLog> TblErrorLogs { get; set; }
        //public virtual DbSet<TblLicense> TblLicenses { get; set; }
        //public virtual DbSet<TblLicenseFileOnSystem> TblLicenseFileOnSystems { get; set; }
        //public virtual DbSet<TblPic> TblPics { get; set; }
        //public virtual DbSet<TblRole> TblRoles { get; set; }
        //public virtual DbSet<TblStaff> TblStaffs { get; set; }
        //public virtual DbSet<TblUser> TblUsers { get; set; }
        //public virtual DbSet<TblUserRole> TblUserRoles { get; set; }
        //public virtual DbSet<TblUserType> TblUserTypes { get; set; }
        //public virtual DbSet<UserTypeUpdate> UserTypeUpdates { get; set; }
        //public virtual DbSet<Vw30DaysExpiry> Vw30DaysExpiries { get; set; }
        //public virtual DbSet<VwDashboard> VwDashboards { get; set; }
        //public virtual DbSet<VwLicense> VwLicenses { get; set; }
        //public virtual DbSet<VwRptCategoryBussLicense> VwRptCategoryBussLicenses { get; set; }
        //public virtual DbSet<VwRptDetailBussLicense> VwRptDetailBussLicenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= 10.249.1.125;Initial Catalog=BLMSDev;User Id=AppSa;Password=Opuswebsql2017;Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CompetentPersonnel>(entity =>
            {
                entity.HasKey(x => x.PersonnelId);
                entity.Property(e => e.PersonnelId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
