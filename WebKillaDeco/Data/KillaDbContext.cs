using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Models;

namespace WebKillaDeco.Data
{
    public class KillaDbContext : IdentityDbContext<User, Rol, int>
    {
        public KillaDbContext(DbContextOptions<KillaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones muchos a muchos

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Favorites)
                .WithOne(f => f.Client)
                .HasForeignKey(f => f.ClientId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Favorites)
                .WithOne(f => f.Product)
                .HasForeignKey(f => f.ProductId);

            // Restricciones de claves foráneas y otras configuraciones

            modelBuilder.Entity<Address>()
                .HasOne(a => a.User) // Utilizamos la propiedad de navegación User
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<BlogPost>()
                .HasOne(bp => bp.User)
                .WithMany()
                .HasForeignKey(bp => bp.UserId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Carts)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Addresses)
                .WithOne(a =>(Client) a.User) // Utilizamos la propiedad de navegación User
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<CommentBlog>()
                .HasOne(cb => cb.BlogPost)
                .WithMany(bp => bp.CommentsBlog)
                .HasForeignKey(cb => cb.BlogPostId);

            modelBuilder.Entity<DetailOrderSupplier>()
                .HasOne(dos => dos.SupplierOrder)
                .WithMany(so => so.DetailsOrderSupplier)
                .HasForeignKey(dos => dos.SupplierOrderId);

            modelBuilder.Entity<DetailOrderSupplier>()
                .HasOne(dos => dos.Product)
                .WithMany()
                .HasForeignKey(dos => dos.ProductId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.BlogPosts)
                .WithOne(bp =>(Employee) bp.User) // Utilizamos la propiedad de navegación User
                .HasForeignKey(bp => bp.UserId);

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.ClientId, f.ProductId });

            modelBuilder.Entity<Location>()
                .HasOne(l => l.Address)
                .WithMany()
                .HasForeignKey(l => l.AddressId);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.StockItems)
                .WithOne(si => si.Location)
                .HasForeignKey(si => si.LocationId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.ClientId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Address)
                .WithMany()
                .HasForeignKey(p => p.AddressId);

            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(pd => pd.Purchase)
                .WithMany(p => p.PurchaseDetails)
                .HasForeignKey(pd => pd.PurchaseId);

            modelBuilder.Entity<PurchaseDetail>()
                .HasOne(pd => pd.Product)
                .WithMany()
                .HasForeignKey(pd => pd.ProductId);

            modelBuilder.Entity<Qualification>()
                .HasOne(q => q.Product)
                .WithMany(p => p.Qualifications)
                .HasForeignKey(q => q.ProductId);

            modelBuilder.Entity<Qualification>()
                .HasOne(q => q.Client)
                .WithMany(c => c.Qualifications)
                .HasForeignKey(q => q.ClientId);

            modelBuilder.Entity<StockItem>()
                .HasOne(si => si.Location)
                .WithMany(l => l.StockItems)
                .HasForeignKey(si => si.LocationId);

            modelBuilder.Entity<StockItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.StockItems)
                .HasForeignKey(si => si.ProductId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.SupplierOrders)
                .WithOne(so => so.Supplier)
                .HasForeignKey(so => so.SupplierId);

            modelBuilder.Entity<SupplierOrder>()
                .HasMany(so => so.DetailsOrderSupplier)
                .WithOne(dos => dos.SupplierOrder)
                .HasForeignKey(dos => dos.SupplierOrderId);
        }
        // Entidades principales (sin dependencias)
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        // Entidades con dependencias
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; } // Considerando que 'User' tiene las dependencias de 'Address'
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<CommentBlog> CommentsBlog { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<DetailOrderSupplier> DetailOrderSuppliers { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
    }
}