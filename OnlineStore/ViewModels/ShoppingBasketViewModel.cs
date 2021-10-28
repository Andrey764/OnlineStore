using System.Collections.Generic;
using OnlineStore.Core.Abstracts;

namespace OnlineStore.View.ViewModels
{
    public class ShoppingBasketViewModel
    {
        public IEnumerable<IProduct> Products { get; set; }
    }
}