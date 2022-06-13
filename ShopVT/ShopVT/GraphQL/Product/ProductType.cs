using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Model.Model;
using ShopVT.EF;

namespace TodoListQL.GraphQL.Lists
{
    public class ProductType : ObjectType<vB10ProductModel>
    {
        protected override void Configure(IObjectTypeDescriptor<vB10ProductModel> descriptor)
        {
            descriptor.Description("This model is used as product for the to list");

            //descriptor.Field(x => x.code)
            //            .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
            //            .UseDbContext<ShopVTDbContext>()
            //            .Description("This is the list that the product belongs to");
        }

        private class Resolvers
        {
            public IQueryable<B10ProductImgModel> GetItems(vB10ProductModel product, [ScopedService] ShopVTDbContext context)
            {
                return context.B10ProductImg.Where(x => x.ProductCode == product.Code);
            }
        }
    }
}