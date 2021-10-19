using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using OnlineStore.View.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Context;
using OnlineStore.Core.Abstracts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.View.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationContext _db;

        public ContentController(DbContextOptions options) => _db = new ApplicationContext(options);

        public async Task<IActionResult> Details(string id)
        {
            return View(await _db.Products.FirstOrDefaultAsync(p => p.Id == id));
        }

        public async Task<IActionResult> Main(string search, string minPrice, string maxPrice)
        {
            return View(await Filtration(search, ParseToDouble(minPrice), ParseToDouble(maxPrice)));
        }

        private double ParseToDouble(string value)
        {
            if (double.TryParse(value, out var result))
                return result;

            return -1;
        }

        /// <summary>
        /// производит фильтрацию продуктов в соответствии с переданными параметрами
        /// </summary>
        /// <param name="search">часть названия товара, который ищет пользователь</param>
        /// <param name="minPrice">минимальная цена товара</param>
        /// <param name="maxPrice">максимальная цена товара</param>
        /// <returns>возвращает отфильтрованную коллекцию продуктов</returns>
        private async Task<IEnumerable<IProduct>> Filtration(string search, double minPrice, double maxPrice)
        {
            IEnumerable<IProduct> buffer = await _db.Products.ToListAsync();
            if (!string.IsNullOrWhiteSpace(search))
                buffer = buffer.Where(p => p.Title.Contains(search));
            if (minPrice >= 0)
                buffer = buffer.Where(p => p.Price >= minPrice);
            if (maxPrice >= 0)
                buffer = buffer.Where(p => p.Price <= maxPrice);

            return buffer;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}