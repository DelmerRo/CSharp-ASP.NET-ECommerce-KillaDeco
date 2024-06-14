using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebKillaDeco.Areas.Identity.Data;
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

        public void LoadData()
        {
            // Entidades independientes
            if (!_roleManager.Roles.Any())
            {
                LoadRoles();
            }

            // Entidades de tipo Entity
            LoadUsers();
            LoadAddresses();
            LoadClients();
            LoadEmployees();
            LoadSuppliers(); // Aquí se llama al nuevo método
            

            // Entidades con dependencias
            LoadCategories();
            LoadSubCategories();
            LoadCoupons();
            LoadLocations(); // Aquí se llama al nuevo método
            LoadProducts();
            LoadStockItems();
            LoadFavorites();
            LoadCarts();
            LoadCartItems();
            LoadPurchases();
            LoadPurchaseDetails();
            LoadQualifications();
            LoadSupplierOrders();
            LoadDetailOrderSuppliers();
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

        private void LoadUsers()
        {
            try
            {
                if (!_context.Admins.Any())
                {
                    List<User> users = UserInMemory.GetUsers();
                    var nameRole = "Admin";
                    foreach (User anUser in users)
                    {
                        if (!string.IsNullOrWhiteSpace(anUser.Email))
                        {
                            Console.WriteLine($"Procesando usuario: {anUser.Email}");

                            var existingUser = _userManager.FindByEmailAsync(anUser.Email).Result;
                            if (existingUser == null)
                            {
                                Console.WriteLine($"Creando usuario: {anUser.Email}");
                                // Usamos el correo electrónico como nombre de usuario
                                anUser.UserName = anUser.Email;
                                var seCreoUsuario = _userManager.CreateAsync(anUser, passwordDefault).Result;
                                if (seCreoUsuario.Succeeded)
                                {
                                    Console.WriteLine($"Usuario creado exitosamente: {anUser.Email}");
                                    _userManager.AddToRoleAsync(anUser, nameRole).Wait();
                                }
                                else
                                {
                                    LogIdentityErrors(seCreoUsuario.Errors);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"El usuario ya existe: {anUser.Email}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Correo electrónico vacío para usuario: {anUser.FullName}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo una excepción: {ex.Message}");
                // También puedes registrar la excepción completa si lo deseas
                Console.WriteLine($"Detalles de la excepción: {ex}");
            }
        }


        private void LogIdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine($"Error: {error.Code}, {error.Description}");
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
                        var existingUser = _userManager.FindByEmailAsync(supplier.Email).Result;
                        if (existingUser == null)
                        {
                            supplier.UserName = supplier.Email;
                            var supplierCreated = _userManager.CreateAsync(supplier, passwordDefault).Result;
                            if (supplierCreated.Succeeded)
                            {
                                _userManager.AddToRoleAsync(supplier, roleName).Wait();
                            }
                            else
                            {
                                LogIdentityErrors(supplierCreated.Errors);
                            }
                        }
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadLocations()
        {
            if (!_context.Locations.Any())
            {
                var locations = LocationInMemory.GetLocations();
                foreach (var location in locations)
                {
                    var existingLocation = _context.Locations.FirstOrDefault(l => l.LocationId == location.LocationId);
                    if (existingLocation == null)
                    {
                        _context.Locations.Add(location);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadAddresses()
        {
            if (!_context.Addresses.Any())
            {
                var addresses = AddressInMemory.GetAddresses();
                foreach (var address in addresses)
                {
                    if (!_context.Addresses.Any(a => a.AddressId == address.AddressId))
                    {
                        _context.Addresses.Add(address);
                    }
                }
                _context.SaveChanges();
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
                        var existingClientr = _userManager.FindByEmailAsync(client.Email).Result;
                        if (existingClientr == null)
                        {
                            client.UserName = client.Email;
                            var clientCreated = _userManager.CreateAsync(client, passwordDefault).Result;
                            if (clientCreated.Succeeded)
                            {
                                _userManager.AddToRoleAsync(client, roleName).Wait();
                            }
                            else
                            {
                                LogIdentityErrors(clientCreated.Errors);
                            }
                        }
                    }
                }
                _context.SaveChanges();
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
                        var existingUser = _userManager.FindByEmailAsync(employee.Email).Result;
                        if (existingUser == null)
                        {
                            employee.UserName = employee.Email;
                            var employeeCreated = _userManager.CreateAsync(employee, passwordDefault).Result;
                            if (employeeCreated.Succeeded)
                            {
                                _userManager.AddToRoleAsync(employee, roleName).Wait();
                            }
                            else
                            {
                                LogIdentityErrors(employeeCreated.Errors);
                            }
                        }
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadSubCategories()
        {
            if (!_context.SubCategories.Any())
            {
                var subCategories = SubCategoryInMemory.GetSubCategories();
                foreach (var subCategory in subCategories)
                {
                    var existingSubCategory = _context.SubCategories.FirstOrDefault(sc => sc.Name == subCategory.Name);
                    if (existingSubCategory == null)
                    {
                        _context.Add(subCategory);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadAnswers()
        {
            if (!_context.Answers.Any())
            {
                var answers = AnswerInMemory.GetAnswers();
                foreach (var answer in answers)
                {
                    var answerFound = _context.Answers.FirstOrDefault(a => a.EmployeeId == answer.EmployeeId && a.QuestionId == answer.QuestionId);
                    if (answerFound == null)
                    {
                        _context.Add(answer);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadQuestions()
        {
            if (!_context.Questions.Any())
            {
                var questions = QuestionInMemory.GetQuestions();
                foreach (var question in questions)
                {
                    var questionFound = _context.Questions.FirstOrDefault(q => q.ClientId == question.ClientId && q.ProductId == question.ProductId);
                    if (questionFound == null)
                    {
                        _context.Questions.Add(question);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadCarts()
        {
            if (!_context.Carts.Any())
            {
                var carts = CartInMemory.GetCarts();
                foreach (var cart in carts)
                {
                    var cartFound = _context.Carts.FirstOrDefault(c => c.ClientId == cart.ClientId);
                    if (cartFound == null)
                    {
                        _context.Carts.Add(cart);
                    }
                }
                _context.SaveChanges();
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
                            ImageUrl = category.ImageUrl,
                            IconUrl = category.IconUrl
                        };
                        _context.Categories.Add(newCategory);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadCoupons()
        {
            if (!_context.Coupons.Any())
            {
                var coupons = CouponInMemory.GetCoupons();
                foreach (var coupon in coupons)
                {
                    var existingCoupon = _context.Coupons.FirstOrDefault(c => c.Code == coupon.Code);
                    if (existingCoupon == null)
                    {
                        _context.Coupons.Add(coupon);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadDetailOrderSuppliers()
        {
            if (!_context.DetailOrderSuppliers.Any())
            {
                var supplierOrderDetails = DetailOrderSupplierInMemory.GetDetailOrderSuppliers();
                foreach (var detail in supplierOrderDetails)
                {
                    var existingDetail = _context.DetailOrderSuppliers.FirstOrDefault(d => d.SupplierOrderId == detail.SupplierOrderId && d.ProductId == detail.ProductId);
                    if (existingDetail == null)
                    {
                        _context.DetailOrderSuppliers.Add(detail);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadFavorites()
        {
            if (!_context.Favorites.Any())
            {
                var favorites = FavoriteInMemory.GetFavorites();
                foreach (var favorite in favorites)
                {
                    var existingFavorite = _context.Favorites.FirstOrDefault(f => f.ProductId == favorite.ProductId && f.ClientId == favorite.ClientId);
                    if (existingFavorite == null)
                    {
                        _context.Favorites.Add(favorite);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadProducts()
        {
            if (!_context.Products.Any())
            {
                var products = ProductInMemory.GetProducts();
                foreach (var product in products)
                {
                    if (!_context.Products.Any(p => p.ProductId == product.ProductId))
                    {
                        _context.Products.Add(product);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadPurchaseDetails()
        {
            if (!_context.PurchaseDetails.Any())
            {
                var purchaseDetails = PurchaseDetailInMemory.GetPurchaseDetails();
                foreach (var detail in purchaseDetails)
                {
                    if (!_context.PurchaseDetails.Any(d => d.PurchaseId == detail.PurchaseId && d.ProductId == detail.ProductId))
                    {
                        _context.PurchaseDetails.Add(detail);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadPurchases()
        {
            if (!_context.Purchases.Any())
            {
                var purchases = PurchaseInMemory.GetPurchases();
                foreach (var purchase in purchases)
                {
                    if (!_context.Purchases.Any(p => p.PurchaseId == purchase.PurchaseId))
                    {
                        _context.Purchases.Add(purchase);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadQualifications()
        {
            if (!_context.Qualifications.Any())
            {
                var qualifications = QualificationInMemory.GetQualifications();
                foreach (var qualification in qualifications)
                {
                    if (!_context.Qualifications.Any(q => q.ProductId == qualification.ProductId && q.ClientId == qualification.ClientId))
                    {
                        _context.Qualifications.Add(qualification);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadStockItems()
        {
            if (!_context.StockItems.Any())
            {
                var stockItems = StockItemInMemory.GetStockItems();
                foreach (var stockItem in stockItems)
                {
                    if (!_context.StockItems.Any(si => si.ProductId == stockItem.ProductId && si.StockItemId == stockItem.StockItemId))
                    {
                        _context.StockItems.Add(stockItem);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadSupplierOrders()
        {
            if (!_context.SupplierOrders.Any())
            {
                var supplierOrders = SupplierOrderInMemory.GetSupplierOrders();
                foreach (var order in supplierOrders)
                {
                    var existingOrder = _context.SupplierOrders.FirstOrDefault(o => o.SupplierOrderId == order.SupplierOrderId && o.SupplierId == order.SupplierId);
                    if (existingOrder == null)
                    {
                        _context.SupplierOrders.Add(order);
                    }
                }
                _context.SaveChanges();
            }
        }

        private void LoadCartItems()
        {
            if (!_context.CartItems.Any())
            {
                var cartItems = CartItemInMemory.GetCartItems();
                foreach (var item in cartItems)
                {
                    if (!_context.CartItems.Any(ci => ci.CartId == item.CartId && ci.ProductId == item.ProductId))
                    {
                        _context.CartItems.Add(item);
                    }
                }
                _context.SaveChanges();
            }
        }
    }
}
