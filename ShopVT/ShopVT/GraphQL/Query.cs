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
        [UseDbContext(typeof(ShopVTDbContext))]
        [UseProjection]
        public IQueryable<B10ProductModel> GetLists([ScopedService] ShopVTDbContext ctx)
        {
            return ctx.B10Products;
        }
        //[UseDbContext(typeof(ApiDbContext))]
        //[UseProjection]
        //public IQueryable<ItemData> GetDatas([ScopedService] ShopVTDbContext ctx)
        //{
        //    return ctx.Items;
        //}
    }
}
