using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Model.Model;
using ShopVT.EF;

namespace TodoListQL.GraphQL.Lists
{
    public class ListType : ObjectType<B10ProductModel>
    {
        //protected override void Configure(IObjectTypeDescriptor<B10ProductModel> descriptor)
        //{
        //    descriptor.Description("This model is used as item for the to list");

        //    descriptor.Field(x => x.)
        //                .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
        //                .UseDbContext<ShopVTDbContext>()
        //                .Description("This is the list that the item belongs to");
        //}

        //private class Resolvers
        //{
        //    public IQueryable<B10ProductModel> GetItems(B10ProductModel list, [ScopedService] ShopVTDbContext context)
        //    {
        //        return context.Items.Where(x => x.ListId == list.Id);
        //    }
        //}
    }
}