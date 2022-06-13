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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public virtual DbSet<B00PermisionDetailModel> B00PermisionDetail { get; set; }
        public virtual DbSet<B00AppUserModel> B00AppUser { get; set; }
        public virtual DbSet<B00CommandLogModel> B00CommandLog { get; set; }
        public virtual DbSet<B00ContactModel> B00Contact { get; set; }
        public virtual DbSet<B00EventLogModel> B00EventLog { get; set; }
        public virtual DbSet<B00FooterModel> B00Footer { get; set; }
        public virtual DbSet<B00FunctionModel> B00Function { get; set; }
        public virtual DbSet<B00UserPermisionModel> B00UserPermision { get; set; }
        public virtual DbSet<B10CustomerModel> B10Customer { get; set; }
        public virtual DbSet<B10CustomerAccountModel> B10CustomerAccount { get; set; }
        public virtual DbSet<B10CustomerAddressModel> B10CustomerAddress { get; set; }
        public virtual DbSet<B10EmployeeModel> B10Employee { get; set; }
        public virtual DbSet<B10HomePageModel> B10HomePage { get; set; }
        public virtual DbSet<B10PostModel> B10Post { get; set; }
        public virtual DbSet<B10PostCategoryModel> B10PostCategory { get; set; }
        public virtual DbSet<B10PostTagModel> B10PostTag { get; set; }
        public virtual DbSet<vB10ProductModel> B10Product { get; set; }
        public virtual DbSet<B10ProductCategoryModel> B10ProductCategory { get; set; }
        public virtual DbSet<B10ProductImgModel> B10ProductImg { get; set; }
        public virtual DbSet<B10ProductInformationModel> B10ProductInformation { get; set; }
        public virtual DbSet<B10ProductTagModel> B10ProductTag { get; set; }
        public virtual DbSet<B10SlideModel> B10Slide { get; set; }
        public virtual DbSet<B10TagModel> B10Tag { get; set; }
        public virtual DbSet<B20AnnouncementModel> B20Announcement { get; set; }
        public virtual DbSet<B20ChatsModel> B20Chats { get; set; }
        public virtual DbSet<B20ChatUserModel> B20ChatUser { get; set; }
        public virtual DbSet<B20FlashsaleModel> B20Flashsale { get; set; }
        public virtual DbSet<B20FlashSaleDetailModel> B20FlashSaleDetail { get; set; }
        public virtual DbSet<B20messageModel> B20message { get; set; }
        public virtual DbSet<B20OpenInventoryModel> B20OpenInventory { get; set; }
        public virtual DbSet<B20OrderModel> B20Order { get; set; }
        public virtual DbSet<B20OrderDetailModel> B20OrderDetail { get; set; }
        public virtual DbSet<B20ProductPromotionModel> B20ProductPromotion { get; set; }
        public virtual DbSet<B20ProductReturnModel> B20ProductReturn { get; set; }
        public virtual DbSet<B20PromotionModel> B20Promotion { get; set; }
        public virtual DbSet<B20StockLedgerModel> B20StockLedger { get; set; }

    }
}

