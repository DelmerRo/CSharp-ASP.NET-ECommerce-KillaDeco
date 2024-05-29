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

        private async Task LoadAnswersAsync()
        {
            if (!_context.Answers.Any())
            {
                var answers = AnswerInMemory.GetAnswers();
                foreach (Answer anAnswer in answers)
                {
                    var answerFound = await _context.Answers.FirstOrDefaultAsync(a => a.EmployeeId == anAnswer.EmployeeId && a.QuestionId== anAnswer.QuestionId);
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
                    var questionFound = await _context.Questions.FirstOrDefaultAsync(q => q.ClientId == anQuestion.ClientId && q.ProductId== anQuestion.ProductId);
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
                // Cargar empleados
            }
        }

        private async Task LoadUsersAsync()
        {
            if (!_context.Users.Any())
            {
                // Cargar usuarios
            }
        }

        private async Task LoadAddressesAsync()
        {
            if (!_context.Addresses.Any())
            {
                // Cargar direcciones
            }
        }


        private async Task LoadCartItemsAsync()
        {
            if (!_context.CartItems.Any())
            {
                // Cargar elementos del carrito
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
                // Cargar cupones
            }
        }

        private async Task LoadDetailOrderSuppliersAsync()
        {
            if (!_context.DetailOrderSuppliers.Any())
            {
                // Cargar detalles de orden de proveedores
            }
        }

        private async Task LoadFavoritesAsync()
        {
            if (!_context.Favorites.Any())
            {
                // Cargar favoritos
            }
        }

        private async Task LoadLocationsAsync()
        {
            if (!_context.Locations.Any())
            {
                // Cargar ubicaciones
            }
        }

        private async Task LoadProductsAsync()
        {
            if (!_context.Products.Any())
            {
                // Cargar productos
            }
        }

        private async Task LoadPurchasesAsync()
        {
            if (!_context.Purchases.Any())
            {
                // Cargar compras
            }
        }

        private async Task LoadPurchaseDetailsAsync()
        {
            if (!_context.PurchaseDetails.Any())
            {
                // Cargar detalles de compra
            }
        }

        private async Task LoadQualificationsAsync()
        {
            if (!_context.Qualifications.Any())
            {
                // Cargar calificaciones
            }
        }

        private async Task LoadStockItemsAsync()
        {
            if (!_context.StockItems.Any())
            {
                // Cargar elementos de stock
            }
        }

        private async Task LoadSuppliersAsync()
        {
            if (!_context.Suppliers.Any())
            {
                // Cargar proveedores
            }
        }

        private async Task LoadSupplierOrdersAsync()
        {
            if (!_context.SupplierOrders.Any())
            {
                // Cargar órdenes de proveedores
            }
        }

        // Agrega más métodos privados para cargar otras entidades si es necesario
    }
}
