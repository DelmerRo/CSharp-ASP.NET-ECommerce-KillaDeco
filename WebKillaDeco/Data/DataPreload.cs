using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebKillaDeco.Data;
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

        public async Task LoadDataAsync()
        {
            // Entidades independientes
            if (!_roleManager.Roles.Any())
            {
                await LoadRolesAsync();
            }
            // Entidades de tipo Entity
            await LoadAddressesAsync();
            await LoadUsersAsync();
            await LoadClientsAsync();
            await LoadEmployeesAsync();
            await LoadSuppliersAsync();
            
            // Entidades con dependencias
            await LoadCategoriesAsync();
            await LoadSubCategoriesAsync();
            await LoadCouponsAsync();
            await LoadLocationsAsync();
            await LoadProductsAsync();
            await LoadStockItemsAsync();
            await LoadFavoritesAsync();
            await LoadCartItemsAsync();
            await LoadCartsAsync();
            await LoadPurchasesAsync();
            await LoadPurchaseDetailsAsync();
            await LoadQualificationsAsync();
            await LoadDetailOrderSuppliersAsync();
            await LoadSupplierOrdersAsync();
            await LoadQuestionsAsync();
            await LoadAnswersAsync();
        }

        private async Task LoadRolesAsync()
        {
            await _roleManager.CreateAsync(new Rol { Name = "Admin" });
            await _roleManager.CreateAsync(new Rol { Name = "Employee" });
            await _roleManager.CreateAsync(new Rol { Name = "Client" });
            await _roleManager.CreateAsync(new Rol { Name = "Supplier" });
        }

        private async Task LoadSubCategoriesAsync()
        {
            if (!_context.SubCategories.Any())
            {
                var subCategories = SubCategoryInMemory.GetSubCategories();
                foreach (var subCategory in subCategories)
                {
                    var existingSubCategory = await _context.SubCategories.FirstOrDefaultAsync(sc => sc.Name == subCategory.Name);
                    if (existingSubCategory == null)
                    {
                        _context.Add(subCategory);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadAnswersAsync()
        {
            if (!_context.Answers.Any())
            {
                var answers = AnswerInMemory.GetAnswers();
                foreach (var answer in answers)
                {
                    var answerFound = await _context.Answers.FirstOrDefaultAsync(a => a.EmployeeId == answer.EmployeeId && a.QuestionId == answer.QuestionId);
                    if (answerFound == null)
                    {
                        _context.Add(answer);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadQuestionsAsync()
        {
            if (!_context.Questions.Any())
            {
                var questions = QuestionInMemory.GetQuestions();
                foreach (var question in questions)
                {
                    var questionFound = await _context.Questions.FirstOrDefaultAsync(q => q.ClientId == question.ClientId && q.ProductId == question.ProductId);
                    if (questionFound == null)
                    {
                        _context.Questions.Add(question);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadCartsAsync()
        {
            if (!_context.Carts.Any())
            {
                var carts = CartInMemory.GetCarts();
                foreach (var cart in carts)
                {
                    var cartFound = await _context.Carts.FirstOrDefaultAsync(c => c.ClientId == cart.ClientId);
                    if (cartFound == null)
                    {
                        _context.Carts.Add(cart);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadClientsAsync()
        {
            if (!_context.Clients.Any())
            {
                var clients = ClientInMemory.GetClients();
                var roleName = "Client";
                foreach (var client in clients)
                {
                    if (client.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(client.Email);
                        if (existingUser == null)
                        {
                            var clientCreated = await _userManager.CreateAsync(client, passwordDefault);
                            if (clientCreated.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(client, roleName);
                            }
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadEmployeesAsync()
        {
            if (!_context.Employees.Any())
            {
                var employees = EmployeeInMemory.GetEmployees();
                var roleName = "Employee";
                foreach (var employee in employees)
                {
                    if (employee.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(employee.Email);
                        if (existingUser == null)
                        {
                            var employeeCreated = await _userManager.CreateAsync(employee, passwordDefault);
                            if (employeeCreated.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(employee, roleName);
                            }
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadUsersAsync()
        {
            if (!_context.Users.Any())
            {
                var users = UserInMemory.GetUsers();
                var roleName = "Admin";
                foreach (var user in users)
                {
                    if (user.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(user.Email);
                        if (existingUser == null)
                        {
                            var userCreated = await _userManager.CreateAsync(user, passwordDefault);
                            if (userCreated.Succeeded)
                            {
                                var roleResult = await _userManager.AddToRoleAsync(user, roleName);
                                if (!roleResult.Succeeded)
                                {
                                    LogIdentityErrors(roleResult.Errors);
                                }
                            }
                            else
                            {
                                LogIdentityErrors(userCreated.Errors);
                            }
                        }
                    }
                }
                await _context.SaveChangesAsync();
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

        private async Task LoadAddressesAsync()
        {
            if (!_context.Addresses.Any())
            {
                var addresses = AddressInMemory.GetAddresses();
                foreach (var address in addresses)
                {
                    var existingAddress = await _context.Addresses.FindAsync(address.AddressId);
                    if (existingAddress == null)
                    {
                        _context.Addresses.Add(address);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadCartItemsAsync()
        {
            if (!_context.CartItems.Any())
            {
                var cartItems = CartItemInMemory.GetCartItems();
                foreach (var cartItem in cartItems)
                {
                    var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.CartId == cartItem.CartId && ci.ProductId == cartItem.ProductId);
                    if (existingCartItem == null)
                    {
                        _context.CartItems.Add(cartItem);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadCategoriesAsync()
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
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadCouponsAsync()
        {
            if (!_context.Coupons.Any())
            {
                var coupons = CouponInMemory.GetCoupons();
                foreach (var coupon in coupons)
                {
                    var existingCoupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == coupon.Code);
                    if (existingCoupon == null)
                    {
                        _context.Coupons.Add(coupon);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadDetailOrderSuppliersAsync()
        {
            if (!_context.DetailOrderSuppliers.Any())
            {
                var supplierOrderDetails = DetailOrderSupplierInMemory.GetDetailOrderSuppliers();
                foreach (var detail in supplierOrderDetails)
                {
                    var existingDetail = await _context.DetailOrderSuppliers.FirstOrDefaultAsync(d => d.SupplierOrderId == detail.SupplierOrderId && d.ProductId == detail.ProductId);
                    if (existingDetail == null)
                    {
                        _context.DetailOrderSuppliers.Add(detail);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadFavoritesAsync()
        {
            if (!_context.Favorites.Any())
            {
                var favorites = FavoriteInMemory.GetFavorites();
                foreach (var favorite in favorites)
                {
                    var existingFavorite = await _context.Favorites.FirstOrDefaultAsync(f => f.ProductId == favorite.ProductId && f.ClientId == favorite.ClientId);
                    if (existingFavorite == null)
                    {
                        _context.Favorites.Add(favorite);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadLocationsAsync()
        {
            if (!_context.Locations.Any())
            {
                var locations = LocationInMemory.GetLocations();
                foreach (var location in locations)
                {
                    var existingLocation = await _context.Locations.FindAsync(location.AddressId);
                    if (existingLocation == null)
                    {
                        _context.Locations.Add(location);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadProductsAsync()
        {
            if (!_context.Products.Any())
            {
                var products = ProductInMemory.GetProducts();
                foreach (var product in products)
                {
                    var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Sku == product.Sku);
                    if (existingProduct == null)
                    {
                        _context.Products.Add(product);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadPurchasesAsync()
        {
            if (!_context.Purchases.Any())
            {
                var purchases = PurchaseInMemory.GetPurchases();
                foreach (var purchase in purchases)
                {
                    var existingPurchase = await _context.Purchases.FirstOrDefaultAsync(p => p.ClientId == purchase.ClientId && p.AddressId == purchase.AddressId);
                    if (existingPurchase == null)
                    {
                        _context.Purchases.Add(purchase);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadPurchaseDetailsAsync()
        {
            if (!_context.PurchaseDetails.Any())
            {
                var purchaseDetails = PurchaseDetailInMemory.GetPurchaseDetails();
                foreach (var detail in purchaseDetails)
                {
                    var existingDetail = await _context.PurchaseDetails.FirstOrDefaultAsync(pd => pd.PurchaseId == detail.PurchaseId && pd.ProductId == detail.ProductId);
                    if (existingDetail == null)
                    {
                        _context.PurchaseDetails.Add(detail);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadQualificationsAsync()
        {
            if (!_context.Qualifications.Any())
            {
                var qualifications = QualificationInMemory.GetQualifications();
                foreach (var qualification in qualifications)
                {
                    var existingQualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.ProductId == qualification.ProductId && q.ClientId == qualification.ClientId);
                    if (existingQualification == null)
                    {
                        _context.Qualifications.Add(qualification);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadStockItemsAsync()
        {
            if (!_context.StockItems.Any())
            {
                var stockItems = StockItemInMemory.GetStockItems();
                foreach (var stockItem in stockItems)
                {
                    var existingStockItem = await _context.StockItems.FirstOrDefaultAsync(si => si.LocationId == stockItem.LocationId && si.ProductId == stockItem.ProductId);
                    if (existingStockItem == null)
                    {
                        _context.StockItems.Add(stockItem);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadSuppliersAsync()
        {
            if (!_context.Suppliers.Any())
            {
                var suppliers = SupplierInMemory.GetSuppliers();
                var roleName = "Supplier";
                foreach (var supplier in suppliers)
                {
                    if (supplier.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(supplier.Email);
                        if (existingUser == null)
                        {
                            var supplierCreated = await _userManager.CreateAsync(supplier, passwordDefault);
                            if (supplierCreated.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(supplier, roleName);
                            }
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadSupplierOrdersAsync()
        {
            if (!_context.SupplierOrders.Any())
            {
                var supplierOrders = SupplierOrderInMemory.GetSupplierOrders();
                foreach (var supplierOrder in supplierOrders)
                {
                    var existingSupplierOrder = await _context.SupplierOrders.FirstOrDefaultAsync(so => so.SupplierId == supplierOrder.SupplierId);
                    if (existingSupplierOrder == null)
                    {
                        _context.SupplierOrders.Add(supplierOrder);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
