using BankAccount.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly MyDbContext _context;

        public CardController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Card>> Get()
        {
            return await _context.Cards.ToListAsync();
        }
    }
}
