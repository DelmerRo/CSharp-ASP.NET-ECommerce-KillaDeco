using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.DataInMemory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebKillaDeco.Models
{
    public class DataPreload
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly KillaDbContext _context;
        private const string passwordDefault = "Password1!";

        public DataPreload(UserManager<User> userManager, RoleManager<Rol> roleManager, KillaDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void LoadData()
        {
            // Entidades independientes
            if (!_roleManager.Roles.Any())
            {
                LoadRoles();
            }
            // Entidades de tipo Entity
            LoadUsers();
            LoadClients();
            LoadEmployees();
            LoadSuppliers();
            LoadAddresses();
             

            // Entidades con dependencias
             LoadCategories();
             LoadSubCategories();
             LoadCoupons();
             LoadLocations();
             LoadProducts();
             LoadStockItems();
             LoadFavorites();
             LoadCartItems();
             LoadCarts();
             LoadPurchases();
             LoadPurchaseDetails();
             LoadQualifications();
             LoadDetailOrderSuppliers();
             LoadSupplierOrders();
             LoadQuestions();
             LoadAnswers();
        }

        private void LoadRoles()
        {
            _roleManager.CreateAsync(new Rol() { Name = "Admin" }).Wait();
            _roleManager.CreateAsync(new Rol() { Name = "Employee" }).Wait();
            _roleManager.CreateAsync(new Rol() { Name = "Client" }).Wait();
            _roleManager.CreateAsync(new Rol() { Name = "Supplier" }).Wait();

        }

        private void LoadSubCategories()
        {
            if (!_context.SubCategories.Any())
            {
                var subCategories = SubCategoryInMemory.GetSubCategories();
                foreach (var subCategory in subCategories)
                {
                    var existingSubCategory =  _context.SubCategories.FirstOrDefault(sc => sc.Name == subCategory.Name);
                    if (existingSubCategory == null)
                    {
                        _context.Add(subCategory);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadAnswers()
        {
            if (!_context.Answers.Any())
            {
                var answers = AnswerInMemory.GetAnswers();
                foreach (var answer in answers)
                {
                    var answerFound =  _context.Answers.FirstOrDefault(a => a.EmployeeId == answer.EmployeeId && a.QuestionId == answer.QuestionId);
                    if (answerFound == null)
                    {
                        _context.Add(answer);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadQuestions()
        {
            if (!_context.Questions.Any())
            {
                var questions = QuestionInMemory.GetQuestions();
                foreach (var question in questions)
                {
                    var questionFound =  _context.Questions.FirstOrDefault(q => q.ClientId == question.ClientId && q.ProductId == question.ProductId);
                    if (questionFound == null)
                    {
                        _context.Questions.Add(question);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadCarts()
        {
            if (!_context.Carts.Any())
            {
                var carts = CartInMemory.GetCarts();
                foreach (var cart in carts)
                {
                    var cartFound =  _context.Carts.FirstOrDefault(c => c.ClientId == cart.ClientId);
                    if (cartFound == null)
                    {
                        _context.Carts.Add(cart);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadClients()
        {
            if (!_context.Clients.Any())
            {
                var clients = ClientInMemory.GetClients();
                var roleName = "Client";
                foreach (var client in clients)
                {
                    if (client.Email != null)
                    {
                        var existingUser =  _userManager.FindByEmailAsync(client.Email);
                        if (existingUser == null)
                        {
                            var clientCreated =  _userManager.CreateAsync(client, passwordDefault).Result;
                            if (clientCreated.Succeeded)
                            {
                                 _userManager.AddToRoleAsync(client, roleName).Wait();
                            }
                        }
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadEmployees()
        {
            if (!_context.Employees.Any())
            {
                var employees = EmployeeInMemory.GetEmployees();
                var roleName = "Employee";
                foreach (var employee in employees)
                {
                    if (employee.Email != null)
                    {
                        var existingUser =  _userManager.FindByEmailAsync(employee.Email);
                        if (existingUser == null)
                        {
                            var employeeCreated =  _userManager.CreateAsync(employee, passwordDefault).Result;
                            if (employeeCreated.Succeeded)
                            {
                                 _userManager.AddToRoleAsync(employee, roleName).Wait();
                            }
                        }
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadUsers()
        {
            if (!_context.Admins.Any())
            {
                List<User> users = UserInMemory.GetUsers();
                var nameRole = "Admin";
                foreach (User anUser in users)
                {
                    if (_userManager.FindByEmailAsync(anUser.Email).Result == null)
                    {
                        var seCreoUsuario = _userManager.CreateAsync(anUser, passwordDefault).Result;
                        if (seCreoUsuario.Succeeded)
                        {
                            _userManager.AddToRoleAsync(anUser, nameRole).Wait();
                        }
                    }

                }
            }
        }

        private void LogIdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                // Puedes usar cualquier sistema de logging aquí, por ejemplo, Serilog, NLog, etc.
                // Aquí estamos usando Console.WriteLine solo como ejemplo.
                Console.WriteLine($"Code: {error.Code}, Description: {error.Description}");
            }
        }

        private void LoadAddresses()
        {
            if (!_context.Addresses.Any())
            {
                var addresses = AddressInMemory.GetAddresses();
                foreach (var address in addresses)
                {
                    var existingAddress =  _context.Addresses.Find(address.AddressId);
                    if (existingAddress == null)
                    {
                        _context.Addresses.Add(address);
                    }
                }
                _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadCartItems()
        {
            if (!_context.CartItems.Any())
            {
                var cartItems = CartItemInMemory.GetCartItems();
                foreach (var cartItem in cartItems)
                {
                    var existingCartItem =  _context.CartItems.FirstOrDefault(ci => ci.CartId == cartItem.CartId && ci.ProductId == cartItem.ProductId);
                    if (existingCartItem == null)
                    {
                        _context.CartItems.Add(cartItem);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadCategories()
        {
            if (!_context.Categories.Any())
            {
                var categories = CategoryInMemory.GetCategories();
                foreach (var category in categories)
                {
                    if (!_context.Categories.Any(c => c.Name == category.Name))
                    {
                        var newCategory = new Category
                        {
                            Name = category.Name,
                            ImageUrl = category.ImageUrl
                        };
                        _context.Categories.Add(newCategory);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadCoupons()
        {
            if (!_context.Coupons.Any())
            {
                var coupons = CouponInMemory.GetCoupons();
                foreach (var coupon in coupons)
                {
                    var existingCoupon =  _context.Coupons.FirstOrDefault(c => c.Code == coupon.Code);
                    if (existingCoupon == null)
                    {
                        _context.Coupons.Add(coupon);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadDetailOrderSuppliers()
        {
            if (!_context.DetailOrderSuppliers.Any())
            {
                var supplierOrderDetails = DetailOrderSupplierInMemory.GetDetailOrderSuppliers();
                foreach (var detail in supplierOrderDetails)
                {
                    var existingDetail =  _context.DetailOrderSuppliers.FirstOrDefault(d => d.SupplierOrderId == detail.SupplierOrderId && d.ProductId == detail.ProductId);
                    if (existingDetail == null)
                    {
                        _context.DetailOrderSuppliers.Add(detail);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadFavorites()
        {
            if (!_context.Favorites.Any())
            {
                var favorites = FavoriteInMemory.GetFavorites();
                foreach (var favorite in favorites)
                {
                    var existingFavorite =  _context.Favorites.FirstOrDefault(f => f.ProductId == favorite.ProductId && f.ClientId == favorite.ClientId);
                    if (existingFavorite == null)
                    {
                        _context.Favorites.Add(favorite);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadLocations()
        {
            if (!_context.Locations.Any())
            {
                var locations = LocationInMemory.GetLocations();
                foreach (var location in locations)
                {
                    var existingLocation =  _context.Locations.Find(location.AddressId);
                    if (existingLocation == null)
                    {
                        _context.Locations.Add(location);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadProducts()
        {
            if (!_context.Products.Any())
            {
                var products = ProductInMemory.GetProducts();
                foreach (var product in products)
                {
                    var existingProduct =  _context.Products.FirstOrDefault(p => p.Sku == product.Sku);
                    if (existingProduct == null)
                    {
                        _context.Products.Add(product);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadPurchases()
        {
            if (!_context.Purchases.Any())
            {
                var purchases = PurchaseInMemory.GetPurchases();
                foreach (var purchase in purchases)
                {
                    var existingPurchase =  _context.Purchases.FirstOrDefault(p => p.ClientId == purchase.ClientId && p.AddressId == purchase.AddressId);
                    if (existingPurchase == null)
                    {
                        _context.Purchases.Add(purchase);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadPurchaseDetails()
        {
            if (!_context.PurchaseDetails.Any())
            {
                var purchaseDetails = PurchaseDetailInMemory.GetPurchaseDetails();
                foreach (var detail in purchaseDetails)
                {
                    var existingDetail =  _context.PurchaseDetails.FirstOrDefault(pd => pd.PurchaseId == detail.PurchaseId && pd.ProductId == detail.ProductId);
                    if (existingDetail == null)
                    {
                        _context.PurchaseDetails.Add(detail);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadQualifications()
        {
            if (!_context.Qualifications.Any())
            {
                var qualifications = QualificationInMemory.GetQualifications();
                foreach (var qualification in qualifications)
                {
                    var existingQualification =  _context.Qualifications.FirstOrDefault(q => q.ProductId == qualification.ProductId && q.ClientId == qualification.ClientId);
                    if (existingQualification == null)
                    {
                        _context.Qualifications.Add(qualification);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadStockItems()
        {
            if (!_context.StockItems.Any())
            {
                var stockItems = StockItemInMemory.GetStockItems();
                foreach (var stockItem in stockItems)
                {
                    var existingStockItem =  _context.StockItems.FirstOrDefault(si => si.LocationId == stockItem.LocationId && si.ProductId == stockItem.ProductId);
                    if (existingStockItem == null)
                    {
                        _context.StockItems.Add(stockItem);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadSuppliers()
        {
            if (!_context.Suppliers.Any())
            {
                var suppliers = SupplierInMemory.GetSuppliers();
                var roleName = "Supplier";
                foreach (var supplier in suppliers)
                {
                    if (supplier.Email != null)
                    {
                        var existingUser =  _userManager.FindByEmailAsync(supplier.Email);
                        if (existingUser == null)
                        {
                            var supplierCreated =  _userManager.CreateAsync(supplier, passwordDefault).Result;
                            if (supplierCreated.Succeeded)
                            {
                                 _userManager.AddToRoleAsync(supplier, roleName);
                            }
                        }
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }

        private void LoadSupplierOrders()
        {
            if (!_context.SupplierOrders.Any())
            {
                var supplierOrders = SupplierOrderInMemory.GetSupplierOrders();
                foreach (var supplierOrder in supplierOrders)
                {
                    var existingSupplierOrder =  _context.SupplierOrders.FirstOrDefault(so => so.SupplierId == supplierOrder.SupplierId);
                    if (existingSupplierOrder == null)
                    {
                        _context.SupplierOrders.Add(supplierOrder);
                    }
                }
                 _context.SaveChangesAsync().Wait();
            }
        }
    }
}
