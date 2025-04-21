﻿using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Services
{
    public class ProductServices : EntityBaseRepository<Product>,IProductServices
    {

        public ProductServices(EcommerceDbContext contetx) : base(contetx)
        {

        }
    }
}
