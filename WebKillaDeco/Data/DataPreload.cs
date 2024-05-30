using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebKillaDeco.Data;
using WebKillaDeco.DataInMemory;

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
            await LoadCategoriesAsync();
            await LoadSubCategoriesAsync();
            await LoadCouponsAsync();
            await LoadLocationsAsync();
            await LoadSuppliersAsync();

            // Entidades con dependencias
            await LoadUsersAsync();
            await LoadClientsAsync();
            await LoadEmployeesAsync();
            await LoadAddressesAsync();
            await LoadProductsAsync();
            await LoadStockItemsAsync();
            await LoadFavoritesAsync();
            await LoadCartItemsAsync();
            await LoadCartAsync();
            await LoadPurchasesAsync();
            await LoadPurchaseDetailsAsync();
            await LoadQualificationsAsync();
            await LoadDetailOrderSuppliersAsync();
            await LoadSupplierOrdersAsync();
            await LoadQuestionsAsync();
            await LoadAnswersAsync();

        }

        private async Task LoadSubCategoriesAsync()
        {
            if (!_context.SubCategories.Any())
            {
                var subCategories = SubCategoryInMemory.GetSubCategories();

                foreach (var subCategory in subCategories)
                {
                    var existingSubCategory = await _context.SubCategories.FirstOrDefaultAsync(sc => sc.SubCategoryId == subCategory.SubCategoryId);

                    if (existingSubCategory == null)
                    {
                        _context.SubCategories.Add(subCategory);
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
                foreach (Answer anAnswer in answers)
                {
                    var answerFound = await _context.Answers.FirstOrDefaultAsync(a => a.EmployeeId == anAnswer.EmployeeId && a.QuestionId == anAnswer.QuestionId);
                    if (answerFound == null)
                    {
                        _context.Add(anAnswer);
                        _context.SaveChangesAsync().Wait();
                    }
                }
            }
        }

        private async Task LoadQuestionsAsync()
        {
            if (!_context.Questions.Any())
            {
                var questions = QuestionInMemory.GetQuestions();
                foreach (var anQuestion in questions)
                {
                    var questionFound = await _context.Questions.FirstOrDefaultAsync(q => q.ClientId == anQuestion.ClientId && q.ProductId == anQuestion.ProductId);
                    if (questionFound == null)
                    {
                        _context.Questions.Add(anQuestion);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadCartAsync()
        {
            if (!_context.Carts.Any())
            {
                var carts = CartInMemory.GetCarts();
                foreach (var anCart in carts)
                {
                    var cartsFound = await _context.Carts.FirstOrDefaultAsync(carts => carts.ClientId == anCart.ClientId);
                    if (cartsFound == null)
                    {
                        _context.Carts.Add(anCart);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadRolesAsync()
        {
            await _roleManager.CreateAsync(new Rol { Name = "User" });
            await _roleManager.CreateAsync(new Rol { Name = "Employee" });
            await _roleManager.CreateAsync(new Rol { Name = "Client" });
            await _roleManager.CreateAsync(new Rol { Name = "Supplier" });
        }

        private async Task LoadClientsAsync()
        {
            if (!_context.Clients.Any())
            {
                var clients = ClientInMemory.GetClients();
                var nombreRol = "Client";
                foreach (var anClient in clients)
                {
                    if (anClient.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(anClient.Email);
                        if (existingUser == null)
                        {
                            var clientCreated = await _userManager.CreateAsync(anClient, passwordDefault);
                            if (clientCreated.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(anClient, nombreRol);
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
                var nombreRol = "Employee";
                foreach (var anEmployee in employees)
                {
                    if (anEmployee.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(anEmployee.Email);
                        if (existingUser == null)
                        {
                            var employeeCreated = await _userManager.CreateAsync(anEmployee, passwordDefault);
                            if (employeeCreated.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(anEmployee, nombreRol);
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
                var nombreRol = "User";
                foreach (var anUser in users)
                {
                    if (anUser.Email != null)
                    {
                        var existingUser = await _userManager.FindByEmailAsync(anUser.Email);
                        if (existingUser == null)
                        {
                            var userCreated = await _userManager.CreateAsync(anUser, passwordDefault);
                            if (userCreated.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(anUser, nombreRol);
                            }
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadAddressesAsync()
        {
            if (!_context.Addresses.Any())
            {
                var addresses = AddressInMemory.GetAddresses();

                foreach (var anAddress in addresses)
                {
                    var existingAddress = await _context.Addresses.FindAsync(anAddress.AddressId);

                    if (existingAddress == null)
                    {
                        _context.Addresses.Add(anAddress);
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
                foreach (var unaCategoria in categories)
                {
                    if (!_context.Categories.Any(c => c.Name == unaCategoria.Name))
                    {
                        var categoria = new Category
                        {
                            Name = unaCategoria.Name,
                            ImageUrl = unaCategoria.ImageUrl
                        };
                        _context.Categories.Add(categoria);
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
                    var existingCoupon = await _context.Coupons.FirstOrDefaultAsync(cou => cou.Code == coupon.Code);

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

                foreach (var anSupplierOrderDetail in supplierOrderDetails)
                {
                    var existingSupplierOrderDetail = await _context.DetailOrderSuppliers.FirstOrDefaultAsync(sod => sod.SupplierOrderId == anSupplierOrderDetail.SupplierOrderId && sod.ProductId == anSupplierOrderDetail.ProductId);

                    if (existingSupplierOrderDetail == null)
                    {
                        _context.DetailOrderSuppliers.Add(anSupplierOrderDetail);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        private async Task LoadFavoritesAsync()
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

        private async Task LoadLocationsAsync()
        {
            if (!_context.Locations.Any())
            {
                var locations = LocationInMemory.GetLocations();

                foreach (var location in locations)
                {
                    var existingLocation = await _context.Locations.FindAsync(location.AddressId );

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
                    var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Sku == product.Sku && p.ProductId == product.ProductId);

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
                var nombreRol = "Employee";
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
                                await _userManager.AddToRoleAsync(supplier, nombreRol);
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


        // Agrega más métodos privados para cargar otras entidades si es necesario
    }
}
