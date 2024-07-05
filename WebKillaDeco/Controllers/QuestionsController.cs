using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Helpers;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly UserManager<User> _userManager;


        public QuestionsController(KillaDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       // GET: Questions
public async Task<IActionResult> Index(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

            var questions = await _context.Questions
                .Include(a =>a.Answer)
                .Include(a => a.Client)
                .Include(a => a.Product)
                .Where(q => q.ProductId == id)
             .ToListAsync();

            foreach (var question in questions)
            {
                if (question.Client == null)
                {
                    Console.WriteLine($"Question {question.Id} tiene un ClientId null");
                }
                else
                {
                    Console.WriteLine($"Question {question.Id} tiene un ClientId {question.ClientId}");
                }
            }

            return View(questions);
}



        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Product)
                 .Include(q => q.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        [Authorize(Roles = Config.RolClient)]
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
[ValidateAntiForgeryToken]
        [Authorize(Roles = Config.RolClient)]
        public async Task<IActionResult> Create(int productId, string description)
{
    try
    {
        // Obtener el cliente actualmente logueado
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null)
        {
            return Unauthorized(); // Devolver 401 si no hay usuario logueado
        }

        var question = new Question
        {
            ClientId = currentUser.Id,
            ProductId = productId,
            Description = description,
            PublicationDate = DateTime.Now
        };

        if (ModelState.IsValid)
        {
            _context.Add(question);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        return BadRequest(ModelState); // Devolver errores de validación
    }
    catch (Exception ex)
    {
        // Log de la excepción (puedes usar ILogger aquí)
        // Puedes devolver un mensaje de error genérico
        return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
    }
}

        [HttpGet]
        public async Task<IActionResult> GetQuestionsPartial(int productId)
        {
            // Obtener el cliente actualmente logueado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized(); // Devolver 401 si no hay usuario logueado
            }

            try
            {
                // Obtener la última pregunta agregada por el usuario actual para el producto dado
                var latestQuestion = await _context.Questions// Incluir información del cliente asociado a la pregunta
                    .Where(q => q.ProductId == productId && q.ClientId == currentUser.Id)
                    .OrderByDescending(q => q.PublicationDate)
                    .FirstOrDefaultAsync();

                if (latestQuestion == null)
                {
                    // Si no se encontró ninguna pregunta, devolver un mensaje o algo adecuado
                    return PartialView("_NoQuestionsPartial"); // Puedes crear una vista parcial para manejar este caso
                }

                return PartialView("_QuestionPartial", latestQuestion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor al obtener la última pregunta.");
            }
        }





        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator", question.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", question.ProductId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ProductId,description,publicationDate")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator", question.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", question.ProductId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Client)
                .Include(q => q.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'KillaDbContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
          return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
