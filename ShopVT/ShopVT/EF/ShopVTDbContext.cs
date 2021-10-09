using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopVT.EF
{
    public class ShopVTDbContext : DbContext
    {
        public ShopVTDbContext(DbContextOptions<ShopVTDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<B00ActionsPermisionModel> B00ActionsPermisions { get; set; }
        public DbSet<B00AppUserModel> B00AppUsers { get; set; }
        public DbSet<B00CommandLogModel> B00CommandLogs { get; set; }
        public DbSet<B00ContactModel> B00Contacts { get; set; }
        public DbSet<B00EventLogModel> B00EventLogs { get; set; }
        public DbSet<B00FooterModel> B00Footers { get; set; }
        public DbSet<B00FunctionModel> B00Functions { get; set; }
        public DbSet<B00UserPermisionModel> B00UserPermisions { get; set; }
        public DbSet<B10CustomerModel> B10Customers { get; set; }
        public DbSet<B10CustomerAccountModel> B10CustomerAccounts { get; set; }
        public DbSet<B10CustomerAddressModel> B10CustomerAddresss { get; set; }
        public DbSet<B10EmployeeModel> B10Employees { get; set; }
        public DbSet<B10HomePageModel> B10HomePages { get; set; }
        public DbSet<B10PostModel> B10Posts { get; set; }
        public DbSet<B10PostCategoryModel> B10PostCategorys { get; set; }
        public DbSet<B10PostTagModel> B10PostTags { get; set; }
        public DbSet<B10ProductModel> B10Products { get; set; }
        public DbSet<B10ProductCategoryModel> B10ProductCategorys { get; set; }
        public DbSet<B10ProductImgModel> B10ProductImgs { get; set; }
        public DbSet<B10ProductInformationModel> B10ProductInformations { get; set; }
        public DbSet<B10ProductTagModel> B10ProductTags { get; set; }
        public DbSet<B10SlideModel> B10Slides { get; set; }
        public DbSet<B10TagModel> B10Tags { get; set; }
        public DbSet<B20AnnouncementModel> B20Announcements { get; set; }
        public DbSet<B20ChatsModel> B20Chatss { get; set; }
        public DbSet<B20ChatUserModel> B20ChatUsers { get; set; }
        public DbSet<B20FlashsaleModel> B20Flashsales { get; set; }
        public DbSet<B20FlashSaleDetailModel> B20FlashSaleDetails { get; set; }
        public DbSet<B20messageModel> B20messages { get; set; }
        public DbSet<B20OpenInventoryModel> B20OpenInventorys { get; set; }
        public DbSet<B20OrderModel> B20Orders { get; set; }
        public DbSet<B20OrderDetailModel> B20OrderDetails { get; set; }
        public DbSet<B20ProductPromotionModel> B20ProductPromotions { get; set; }
        public DbSet<B20ProductReturnModel> B20ProductReturns { get; set; }
        public DbSet<B20PromotionModel> B20Promotions { get; set; }
        public DbSet<B20StockLedgerModel> B20StockLedgers { get; set; }

    }
}

