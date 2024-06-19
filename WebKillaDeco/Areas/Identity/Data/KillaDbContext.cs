using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Models;

namespace WebKillaDeco.Areas.Identity.Data
{
    public class KillaDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public KillaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para CartItem
            modelBuilder.Entity<CartItem>()
                .Property(c => c.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // Configuración para Coupon
            modelBuilder.Entity<Coupon>()
                .Property(c => c.Discount)
                .HasColumnType("decimal(18,2)");

            // Configuración para DetailOrderSupplier
            modelBuilder.Entity<DetailOrderSupplier>()
                .Property(d => d.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // Configuración para Employee
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            // Configuración para Product
            modelBuilder.Entity<Product>()
                .Property(p => p.CurrentPrice)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
                .Property(p => p.Discount)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
                .Property(p => p.Weight)
                .HasColumnType("decimal(18,2)");

            // Configuración para Purchase
            modelBuilder.Entity<Purchase>()
                .Property(p => p.Total)
                .HasColumnType("decimal(18,2)");

            // Configuración para PurchaseDetail
            modelBuilder.Entity<PurchaseDetail>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                 .HasForeignKey<Address>(a => a.UserId)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Purchases)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Carts)
                .WithOne(cart => cart.Client)
                .HasForeignKey(cart => cart.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Qualifications)
                .WithOne(q => q.Client)
                .HasForeignKey(q => q.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Favorites)
                .WithOne(f => f.Client)
                .HasForeignKey(f => f.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Questions)
                .WithOne(q => q.Client)
                .HasForeignKey(q => q.ClientId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.StockItems)
                .WithOne(si => si.Product)
                .HasForeignKey(si => si.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Qualifications)
                .WithOne(q => q.Product)
                .HasForeignKey(q => q.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Favorites)
                .WithOne(f => f.Product)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Questions)
                .WithOne(q => q.Product)
                .HasForeignKey(q => q.ProductId);

            modelBuilder.Entity<Purchase>()
                .HasMany(p => p.PurchaseDetails)
                .WithOne(pd => pd.Purchase)
                .HasForeignKey(pd => pd.PurchaseId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.SupplierOrders)
                .WithOne(so => so.Supplier)
                .HasForeignKey(so => so.SupplierId);

            modelBuilder.Entity<SupplierOrder>()
                .HasMany(so => so.DetailsOrderSupplier)
                .WithOne(dos => dos.SupplierOrder)
                .HasForeignKey(dos => dos.SupplierOrderId);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.StockItems)
                .WithOne(si => si.Location)
                .HasForeignKey(si => si.LocationId);

            modelBuilder.Entity<Location>()
           .HasOne(l => l.Address)
           .WithOne(a => a.Location)
           .HasForeignKey<Address>(a => a.LocationId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Answers)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId);

            modelBuilder.Entity<SubCategory>()
                .HasMany(sc => sc.Products)
                .WithOne(p => p.SubCategories)
                .HasForeignKey(p => p.SubCategoryId);

            //Definicion de nonmbre de tablas
            modelBuilder.Entity<IdentityUser<int>>().ToTable("Users");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UsersRoles");
        }

        internal async Task SaveIconAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<DetailOrderSupplier> DetailOrderSuppliers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }

    }

}