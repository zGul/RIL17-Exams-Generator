﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ril17ExamsGenerator.Dal;
using ril17ExamsGenerator.Models;

namespace ril17ExamsGenerator.Controllers
{
    public class ExamsController : Controller
    {
        private readonly ExamGeneratorContext _context;

        public ExamsController(ExamGeneratorContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            return View(await _context.exams.ToListAsync());
        }     
        
        public void ControlExam()
        {

        }
       
        public async Task<IActionResult> Answer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exam = await _context.exams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View("Answer");
        }

        public IActionResult Validate(string name, string nombre, string duree)
        {
            //Insert data
            int nb = int.Parse(nombre);
            List<Question> tabQuestion = new List<Question>();
            int maxId=1; 
            for (int i = 0; i <= nb; i++)
            {
                Random rdm = new Random();
                //maxId = Dernier ID de la table
                int id = rdm.Next(0,maxId);
                //Récupération des infos de la question
                Question q1 = new Question();
                tabQuestion.Add(q1);
            }
            var optionsBuilder = new DbContextOptionsBuilder<ExamGeneratorContext>();
            var exam = new Exam()
            {
                name = name,
                duree = int.Parse(duree),
                nombre = nb,
                questions = tabQuestion
            };
            using(var _context = new ExamGeneratorContext(optionsBuilder.Options))
            {
                _context.Add(exam);
                //await _context.SaveChangesAsync();
            }
            return View("Validate");
        }

        // GET: Exams/Create
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction("Validate");
            }
            return View(exam);
        }
        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.exams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Exam exam)
        {
            if (id != exam.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.ID))
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
            return View(exam);
        }

        // GET: Exams/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.exams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _context.exams.FindAsync(id);
            _context.exams.Remove(exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            return _context.exams.Any(e => e.ID == id);
        }
    }
}
