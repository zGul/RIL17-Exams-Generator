using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ril17ExamsGenerator.Dal;
using ril17ExamsGenerator.Models;

namespace ril17ExamsGenerator.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ExamGeneratorContext _context;

        public QuestionsController(ExamGeneratorContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(await _context.questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.questions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult CreateYN()
        {
            return View("YesNo");
        }
        public IActionResult CreateSC()
        {
            return View("SingleChoice");
        }
        public IActionResult CreateMC()
        {
            return View("MultipleChoice");
        }

        public IActionResult InsertYN(string name)
        {
            List<Response> responses = new List<Response>();
            var question = new Question()
            {
                question = name,
                type = QuestionType.Y,
                responses = responses
            };
            var rep1 = new Response()
            {
                response = "YES",
                question = question,
                isCorrect = true
            };
            var rep2 = new Response()
            {
                response = "YES",
                question = question,
                isCorrect = false
            };
            responses.Add(rep1);
            responses.Add(rep2);

            question.responses = responses;

            var optionsBuilder = new DbContextOptionsBuilder<ExamGeneratorContext>();
            using (var _context = new ExamGeneratorContext(optionsBuilder.Options))
            {
                _context.Add(question);
                //await _context.SaveChangesAsync();
            }
            return View("Validate");
        }
        public IActionResult InsertSChoice(string name, string q1, string q2, string q3, string q4)
        {
            List<Response> responses = new List<Response>();
            var question = new Question()
            {
                question = name,
                type = QuestionType.U,
                responses = responses
            };
            var rep1 = new Response()
            {
                response = q1,
                question = question,
                isCorrect = true
            };
            var rep2 = new Response()
            {
                response = q2,
                question = question,
                isCorrect = false
            };
            var rep3 = new Response()
            {
                response = q3,
                question = question,
                isCorrect = false
            };
            var rep4 = new Response()
            {
                response = q4,
                question = question,
                isCorrect = false
            };
            responses.Add(rep1);
            responses.Add(rep2);
            responses.Add(rep3);
            responses.Add(rep4);

            question.responses = responses;

            var optionsBuilder = new DbContextOptionsBuilder<ExamGeneratorContext>();
            
            using (var _context = new ExamGeneratorContext(optionsBuilder.Options))
            {
                _context.Add(question);
                //await _context.SaveChangesAsync();
            }
            return View("Validate");
        }
        public IActionResult InsertMChoice(string name, string q1, string q2, string q3, string q4)
        {
            List<Response> responses = new List<Response>();
            var question = new Question()
            {
                question = name,
                type = QuestionType.Y,
                responses = responses
            };
            var rep1 = new Response()
            {
                response = q1,
                question = question,
                isCorrect = true
            };
            var rep2 = new Response()
            {
                response = q2,
                question = question,
                isCorrect = false
            };
            var rep3 = new Response()
            {
                response = q3,
                question = question,
                isCorrect = false
            };
            var rep4 = new Response()
            {
                response = q4,
                question = question,
                isCorrect = false
            };
            
            responses.Add(rep1);
            responses.Add(rep2);
            responses.Add(rep3);
            responses.Add(rep4);

            question.responses = responses;

            var optionsBuilder = new DbContextOptionsBuilder<ExamGeneratorContext>();
            
            using (var _context = new ExamGeneratorContext(optionsBuilder.Options))
            {
                _context.Add(question);
                //await _context.SaveChangesAsync();
            }
            return View("Validate");
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,question,type")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,question,type")] Question question)
        {
            if (id != question.ID)
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
                    if (!QuestionExists(question.ID))
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
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.questions
                .FirstOrDefaultAsync(m => m.ID == id);
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
            var question = await _context.questions.FindAsync(id);
            _context.questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.questions.Any(e => e.ID == id);
        }
    }
}
