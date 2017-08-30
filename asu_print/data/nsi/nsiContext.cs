using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace data.nsi{
public partial class nsiContext : DbContext
    {
        public static void Configure(DbContextOptionsBuilder optionsBuilder,string connectionString){
            optionsBuilder.UseNpgsql(connectionString);
        }
public nsiContext(DbContextOptions<nsiContext> options)
      :base(options)
    { }

        /*
        private string connectionString;

        public nsiContext(IConfigurationRoot configuration,string connectionStringName)
        {
            connectionString= configuration.GetConnectionString(connectionStringName);
        }
        public nsiContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
//*/
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Firm> Firm { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Tree> Tree { get; set; }
        public virtual DbSet<TreeNode> TreeNode { get; set; }
        public virtual DbSet<TreeNodeEmployee> TreeNodeEmployee { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
        public virtual DbSet<ZoneFirm> ZoneFirm { get; set; }

   /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact", "nsi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.IsLocked).HasColumnName("is_locked");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.MailOuter)
                    .HasColumnName("mail_outer")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneCity)
                    .HasColumnName("phone_city")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneMobile)
                    .HasColumnName("phone_mobile")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneRzd)
                    .HasColumnName("phone_rzd")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.PhotoId)
                    .HasColumnName("photo_id")
                    .HasColumnType("varchar")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Contact)
                    .HasForeignKey<Contact>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_contact_employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee", "nsi");

                entity.HasIndex(e => e.Account)
                    .HasName("uk_qm4nlaup2xdco8cc31h545ha6")
                    .IsUnique();

                entity.HasIndex(e => e.AsozCode)
                    .HasName("uk_5dj9h7xb4pruqkm6tynrguwx4")
                    .IsUnique();

                entity.HasIndex(e => e.AsozId)
                    .HasName("uk_ii420ldiog13hxvm7jw1xm5su")
                    .IsUnique();

                entity.HasIndex(e => e.AsutrCode)
                    .HasName("employee_asutr_code_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Code)
                    .HasName("employee_code_key")
                    .IsUnique();

                entity.HasIndex(e => e.DomainObject)
                    .HasName("employee_domain_object_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.EsppCode)
                    .HasName("employee_espp_code_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.EsppId)
                    .HasName("employee_espp_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.FioSearch)
                    .HasName("employee_fio_search_index");

                entity.HasIndex(e => e.FirmId)
                    .HasName("employee_firm_id_index");

                entity.HasIndex(e => e.FtsFio)
                    .HasName("idx_employee_fts_fio");

                entity.HasIndex(e => e.Username)
                    .HasName("employee_username_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_employee'::regclass)");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account");

                entity.Property(e => e.AsozCode)
                    .IsRequired()
                    .HasColumnName("asoz_code");

                entity.Property(e => e.AsozId)
                    .IsRequired()
                    .HasColumnName("asoz_id");

                entity.Property(e => e.AsutrCode)
                    .IsRequired()
                    .HasColumnName("asutr_code");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.DomainObject)
                    .IsRequired()
                    .HasColumnName("domain_object")
                    .HasColumnType("varchar")
                    .HasMaxLength(32);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar")
                    .HasMaxLength(80);

                entity.Property(e => e.EsppCode)
                    .IsRequired()
                    .HasColumnName("espp_code")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.EsppId)
                    .IsRequired()
                    .HasColumnName("espp_id");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasColumnType("varchar")
                    .HasMaxLength(300);

                entity.Property(e => e.FioSearch).HasColumnName("fio_search");

                entity.Property(e => e.FirmId).HasColumnName("firm_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.FtsFio).HasColumnName("fts_fio");

                entity.Property(e => e.IsExternal).HasColumnName("is_external");

                entity.Property(e => e.IsLocked).HasColumnName("is_locked");

                entity.Property(e => e.IsVip).HasColumnName("is_vip");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar")
                    .HasMaxLength(64);

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.StatusCode).HasColumnName("status_code");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.FirmId)
                    .HasConstraintName("fk_employee_firm_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("fk_employee_post_id");
            });

            modelBuilder.Entity<Firm>(entity =>
            {
                entity.ToTable("firm", "nsi");

                entity.HasIndex(e => e.AsozCode)
                    .HasName("firm_asoz_code_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.AsozId)
                    .HasName("firm_asoz_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Code)
                    .HasName("firm_code_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_firm'::regclass)");

                entity.Property(e => e.AsozCode)
                    .IsRequired()
                    .HasColumnName("asoz_code");

                entity.Property(e => e.AsozId)
                    .IsRequired()
                    .HasColumnName("asoz_id");

                entity.Property(e => e.AsutrCode).HasColumnName("asutr_code");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.FirmMainId).HasColumnName("firm_main_id");

                entity.Property(e => e.FirmZoneId).HasColumnName("firm_zone_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(1024);

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsMain).HasColumnName("is_main");

                entity.Property(e => e.IsZone).HasColumnName("is_zone");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("short_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.FirmMain)
                    .WithMany(p => p.InverseFirmMain)
                    .HasForeignKey(d => d.FirmMainId)
                    .HasConstraintName("fk_firm_main_id");

                entity.HasOne(d => d.FirmZone)
                    .WithMany(p => p.InverseFirmZone)
                    .HasForeignKey(d => d.FirmZoneId)
                    .HasConstraintName("fk_firm_zone_id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.FirmNavigation)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("fk_firm_employee_id");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Firm)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("fk_gmyor4gbjuo3bsn0xup9ghxe9");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post", "nsi");

                entity.HasIndex(e => e.AsozCode)
                    .HasName("uk_d59dlhhrdel8798bb8iy0k1by")
                    .IsUnique();

                entity.HasIndex(e => e.Code)
                    .HasName("post_code_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_post'::regclass)");

                entity.Property(e => e.AsozCode)
                    .IsRequired()
                    .HasColumnName("asoz_code");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("post_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Tree>(entity =>
            {
                entity.ToTable("tree", "nsi");

                entity.HasIndex(e => e.Code)
                    .HasName("uk_tree_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_tree'::regclass)");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasColumnName("caption")
                    .HasColumnType("varchar")
                    .HasMaxLength(80);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar")
                    .HasMaxLength(2048);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<TreeNode>(entity =>
            {
                entity.ToTable("tree_node", "nsi");

                entity.HasIndex(e => e.FirmId)
                    .HasName("idx_tree_node_firm_id");

                entity.HasIndex(e => e.ParentId)
                    .HasName("idx_tree_node_parent_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_tree_node'::regclass)");

                entity.Property(e => e.Caption)
                    .HasColumnName("caption")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.FirmId).HasColumnName("firm_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.TreeId).HasColumnName("tree_id");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.TreeNode)
                    .HasForeignKey(d => d.FirmId)
                    .HasConstraintName("fk_tree_node_firm_id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TreeNode)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("fk_tree_node_employee_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_tree_node_tree_node_id");

                entity.HasOne(d => d.Tree)
                    .WithMany(p => p.TreeNode)
                    .HasForeignKey(d => d.TreeId)
                    .HasConstraintName("fk_tree_node_tree_id");
            });

            modelBuilder.Entity<TreeNodeEmployee>(entity =>
            {
                entity.ToTable("tree_node_employee", "nsi");

                entity.HasIndex(e => new { e.TreeNodeId, e.EmployeeId, e.IsDeputy })
                    .HasName("uk_tree_node_employee")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_tree_node_employee'::regclass)");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsDeputy).HasColumnName("is_deputy");

                entity.Property(e => e.LastUpdated).HasColumnName("last_updated");

                entity.Property(e => e.TreeNodeId).HasColumnName("tree_node_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TreeNodeEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tree_node_employee_employee_id_fkey");

                entity.HasOne(d => d.TreeNode)
                    .WithMany(p => p.TreeNodeEmployee)
                    .HasForeignKey(d => d.TreeNodeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tree_node_employee_tree_node_id_fkey");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_zone");

                entity.ToTable("zone", "nsi");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.AsozCode).HasColumnName("asoz_code");

                entity.Property(e => e.CodeEspp)
                    .IsRequired()
                    .HasColumnName("code_espp")
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                entity.Property(e => e.DispGroup)
                    .HasColumnName("disp_group")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsRoad).HasColumnName("is_road");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.MaskCode).HasColumnName("mask_code");

                entity.Property(e => e.ShiftGroup)
                    .HasColumnName("shift_group")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.ShiftMail)
                    .HasColumnName("shift_mail")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.ShiftPhone)
                    .HasColumnName("shift_phone")
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("short_name")
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ZoneFirm>(entity =>
            {
                entity.ToTable("zone_firm", "nsi");

                entity.HasIndex(e => new { e.FirmMainId, e.ZoneId, e.FirmZoneId })
                    .HasName("uk_zone_firm")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('nsi.sq_zone_firm'::regclass)");

                entity.Property(e => e.FirmMainId)
                    .IsRequired()
                    .HasColumnName("firm_main_id");

                entity.Property(e => e.FirmZoneId)
                    .IsRequired()
                    .HasColumnName("firm_zone_id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ZoneId)
                    .IsRequired()
                    .HasColumnName("zone_id");

                entity.HasOne(d => d.FirmMain)
                    .WithMany(p => p.ZoneFirmFirmMain)
                    .HasForeignKey(d => d.FirmMainId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_zone_firm_firm_main");

                entity.HasOne(d => d.FirmZone)
                    .WithMany(p => p.ZoneFirmFirmZone)
                    .HasForeignKey(d => d.FirmZoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_zone_firm_firm_zone");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.ZoneFirm)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_zone_firm_zone_code");
            });

            modelBuilder.HasSequence("sq_employee", "nsi")
                .StartsAt(393409000)
                .IncrementsBy(100);

            modelBuilder.HasSequence("sq_firm", "nsi")
                .StartsAt(22330300)
                .IncrementsBy(100);

            modelBuilder.HasSequence("sq_it_system_service", "nsi");

            modelBuilder.HasSequence("sq_it_system_tag", "nsi");

            modelBuilder.HasSequence("sq_post", "nsi")
                .StartsAt(23515600)
                .IncrementsBy(100);

            modelBuilder.HasSequence("sq_service_state", "nsi");

            modelBuilder.HasSequence("sq_service_subcategory", "nsi");

            modelBuilder.HasSequence("sq_service_type", "nsi");

            modelBuilder.HasSequence("sq_tree", "nsi")
                .StartsAt(200)
                .IncrementsBy(100);

            modelBuilder.HasSequence("sq_tree_node", "nsi")
                .StartsAt(100)
                .IncrementsBy(100);

            modelBuilder.HasSequence("sq_tree_node_employee", "nsi").IncrementsBy(100);

            modelBuilder.HasSequence("sq_zone_firm", "nsi").StartsAt(1800);
        }
    }
}