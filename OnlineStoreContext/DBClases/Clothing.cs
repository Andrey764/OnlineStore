using OnlineStore.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.DBClases
{
    class Clothing : Product, IClothing
    {
        public string Dimensions { get; set; }
        public string FunctionalFeatures { get; set; }
        public string Gender { get; set; }
        public string ClimaticCharacteristics { get; set; }
    }
}
