using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Context;
using OnlineStore.Core.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Core.DBClasses;

namespace OnlineStore.View.Controllers
{
    public class ContentController : Controller
    {
        private ApplicationContext _db;
        public ContentController(DbContextOptions options) => _db = new ApplicationContext(options);

        public async Task<IActionResult> Details(string Id)
        {
            return View(await _db.Products.FirstOrDefaultAsync(p => p.Id == Id));
        }

        public async Task<IActionResult> Main(string search, string minPrice, string maxPrice)
        {
            double minPr, maxPr;
            if (!double.TryParse(minPrice, out minPr))
                minPr = -1;
            if (!double.TryParse(maxPrice, out maxPr))
                maxPr = -1;
            return View("Main", await Filtration(search, minPr, maxPr));
        }

        /// <summary>
        /// производит фильтрацию продуктов в соответствии с переданными параметрами 
        /// </summary>
        /// <param name="search">часть названия товара, который ищет пользователь</param>
        /// <param name="minPrice">минимальная цена товара</param>
        /// <param name="maxPrice">максимальная цена товара</param>
        /// <returns>возвращает отфильтрованую колецию продуктов</returns>
        private async Task<IEnumerable<IProduct>> Filtration(string search, double minPrice, double maxPrice)
        {
            IEnumerable<IProduct> buffer = await _db.Products.ToListAsync();
            if (search != null && search != "")
                buffer = buffer.Where(p => p.Title.Contains(search));
            if (minPrice >= 0)
                buffer = buffer.Where(p => p.Price >= minPrice);
            if (maxPrice >= 0)
                buffer = buffer.Where(p => p.Price <= maxPrice);
            return buffer;
        }
    }
}
