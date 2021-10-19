using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Model.Model;
using ShopVT.EF;

namespace TodoListQL.GraphQL.Lists
{
    public class ProductType : ObjectType<B10ProductModel>
    {
        protected override void Configure(IObjectTypeDescriptor<B10ProductModel> descriptor)
        {
            descriptor.Description("This model is used as product for the to list");

            descriptor.Field(x => x.code)
                        .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
                        .UseDbContext<ShopVTDbContext>()
                        .Description("This is the list that the product belongs to");
        }

        private class Resolvers
        {
            public IQueryable<B10ProductImgModel> GetItems(B10ProductModel product, [ScopedService] ShopVTDbContext context)
            {
                return context.B10ProductImg.Where(x => x.ProductCode == product.code);
            }
        }
    }
}