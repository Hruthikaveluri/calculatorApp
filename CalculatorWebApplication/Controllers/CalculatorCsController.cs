using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalculatorWebApplication.Data;
using CalculatorWebApplication.Models;

namespace CalculatorWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorCsController : ControllerBase
    {
        private readonly CalculatorAppDbContext _context;

        public CalculatorCsController(CalculatorAppDbContext context)
        {
            _context = context;
        }

        GET: api/CalculatorCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculatorC>>> Getcalculator()
        {
           return await _context.calculator.ToListAsync();
        }

        // GET: api/CalculatorCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculatorC>> GetCalculatorC(int id)
        {
           var calculatorC = await _context.calculator.FindAsync(id);

           if (calculatorC == null)
           {
               return NotFound();
           }

           return calculatorC;
        }

        // PUT: api/CalculatorCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculatorC(int id, CalculatorC calculatorC)
        {
           if (id != calculatorC.Id)
           {
               return BadRequest();
           }

           _context.Entry(calculatorC).State = EntityState.Modified;

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!CalculatorCExists(id))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return NoContent();
        }

        // POST: api/CalculatorCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalculatorC>> PostCalculatorC(CalculatorC calculatorC)
        {
           _context.calculator.Add(calculatorC);
           await _context.SaveChangesAsync();

           return CreatedAtAction("GetCalculatorC", new { id = calculatorC.Id }, calculatorC);
        }

        // DELETE: api/CalculatorCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculatorC(int id)
        {
           var calculatorC = await _context.calculator.FindAsync(id);
           if (calculatorC == null)
           {
               return NotFound();
           }

           _context.calculator.Remove(calculatorC);
           await _context.SaveChangesAsync();

           return NoContent();
        }

        private bool CalculatorCExists(int id)
        {
           return _context.calculator.Any(e => e.Id == id);
        }

        
        
            [HttpPut]
            public IActionResult PutCalculator([FromBody] CalculatorC calculator)
            {
                switch (calculator.operation)
                {
                    case '+':
                        calculator.result = calculator.operand1 + calculator.operand2;
                        break;
                    case '-':
                        calculator.result = calculator.operand1 - calculator.operand2;
                        break;
                    case '*':
                        calculator.result = calculator.operand1 * calculator.operand2;
                        break;
                    case '/':
                        if (calculator.operand2 == 0)
                            return BadRequest("Cannot divide by zero.");
                        calculator.result = calculator.operand1 / calculator.operand2;
                        break;
                    default:
                        return BadRequest("Invalid operator. Use +, -, *, or /.");
                }

                return Ok(calculator);
            }
        

    }
}
