using HotChocolate;
using HotChocolate.Data;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using ShopVT.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TodoListGQL.GraphQL
{
    public class Query
    {
        private ShopVTDbContext ctor;

        //[UseDbContext(typeof(ShopVTDbContext))]
        //[UseProjection]
        public Query(ShopVTDbContext shopVTDbContext)
        {
            ctor = shopVTDbContext;
        }
        public IQueryable<B10ProductModel> GetProducts([Service] ShopVTDbContext ctx)
        {
            var s = ctor.B10Product.ToList();
            return ctx.B10Product;
        }
        //[UseDbContext(typeof(ApiDbContext))]
        //[UseProjection]
        //public IQueryable<ItemData> GetDatas([ScopedService] ShopVTDbContext ctx)
        //{
        //    return ctx.Items;
        //}
    }
}
