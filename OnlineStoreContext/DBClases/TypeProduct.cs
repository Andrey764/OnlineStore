﻿using OnlineStore.Core.Abstract;

namespace OnlineStore.Core.DBClases
{
    class TypeProduct : ITypeProduct
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
