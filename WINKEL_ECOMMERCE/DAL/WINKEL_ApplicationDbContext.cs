using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WINKEL_ECOMMERCE.Models;
namespace WINKEL_ECOMMERCE.DAL
{
    public class WINKEL_ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public WINKEL_ApplicationDbContext()
        {
            
        }
        public WINKEL_ApplicationDbContext(DbContextOptions<WINKEL_ApplicationDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ShipItem> ShipItems { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Summer> Summers { get; set; }
        public DbSet<Static> Statics { get; set; }
        public DbSet<SatisfiedCustomer> SatisfiedCustomers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
<<<<<<< HEAD
        public DbSet<AuditLog> AuditLogs { get; set; }
=======
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Sliders>().Property(x => x.Description).HasMaxLength(200);
<<<<<<< HEAD
            modelBuilder.Entity<Comment>().HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
=======
            modelBuilder.Entity<Comment>().HasOne(x => x.Post).WithMany(x=>x.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne(x => x.Parent).WithMany(x=>x.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
            modelBuilder.Entity<SatisfiedCustomer>().HasData(
                new SatisfiedCustomer
                {
                    Id = 1,
                    Image = "person_1.webp",
                    AltImage = "Garreth Smith",
                    Icon = "fas fa-quote-left",
                    Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                    Name = "Garreth Smith",
                    Position = "MARKETING  MANAGER"
                },
                new SatisfiedCustomer
                {
                    Id = 2,
                    Image = "person_2.webp",
                    AltImage = "Garreth Smith",
                    Icon = "fas fa-quote-left",
                    Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                    Name = "Wiktoria Manilla",
                    Position = "SALES  MANAGER"
                },
                new SatisfiedCustomer
                {
                    Id = 3,
                    Image = "person_3.webp",
                    AltImage = "Garreth Smith",
                    Icon = "fas fa-quote-right",
                    Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                    Name = "Wladyslaw Szpilman",
                    Position = "CONTENT MANAGER"
                },
                new SatisfiedCustomer
                {
                    Id = 4,
                    Image = "person_1.webp",
                    AltImage = "Garreth Smith",
                    Icon = "fas fa-quote-left",
                    Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.",
                    Name = "Garreth Smith",
                    Position = "MARKETING  MANAGER"
                });
            modelBuilder.Entity<Post>().Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Comment>().Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Comment>().Property(x => x.LastModifiedAt).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Tag>().Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Tag>().Property(x => x.LastModifiedAt).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Static>().HasData(
                new Static { Id = 1, Count = 10000, Name = "HAPPY CUSTOMERS" },
                new Static { Id = 2, Count = 100, Name = "BRANCHES" },
                new Static { Id = 3, Count = 1000, Name = "PARTNER" },
                new Static { Id = 4, Count = 10000, Name = "AWARDS" });
            modelBuilder.Entity<Summer>().HasData(
                new Summer
                {
                    Id = 1,
                    RightImage = "about-1.jpg",
                    RightHeading = "NEW WOMEN'S CLOTHING SUMMER COLLECTION 2019",
                    RightContent = " NEW WOMEN'S CLOTHING SUMMER COLLECTION 2019\r\n                Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.",
                    LeftImage = "about-2.webp",
                    LeftHeading = "NEW MEN'S CLOTHING SUMMER COLLECTION 2019",
                    LeftContent = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean."
                });
            modelBuilder.Entity<Product>().Property(x => x.Price).HasDefaultValueSql("00.00");
            modelBuilder.Entity<Product>().Property(x => x.DiscountPrice).HasDefaultValueSql("00.00");
            modelBuilder.Entity<Product>().Property(x => x.CreatedAt).HasDefaultValueSql("SYSDATETIME()");
            modelBuilder.Entity<Ship>().HasData(
                new Ship
                {
                    Id = 1,
                    Image = "about.webp",
                    AltImage = "This is a photo",
                    Link = "https://vimeo.com/45830194",
                    Header = "Better Way to Ship Your Products",
                    Description = "But nothing the copy said could convince her and so it didn’t take long until a few insidious Copy Writers ambushed her, made her drunk with Longe and Parole and dragged her into their agency, where they abused her for their."
                });
            modelBuilder.Entity<ShipItem>().HasData(
                new ShipItem
                {
                    Id = 1,
                    Icon = "fas fa-tablet-alt",
                    Title = "REFUND POLICY",
                    Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
                    ShipId = 1
                },
                new ShipItem
                {
                    Id = 2,
                    Icon = "fas fa-tablet-alt",
                    Title = "REFUND POLICY",
                    Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
                    ShipId = 1
                },
                new ShipItem
                {
                    Id = 3,
                    Icon = "fas fa-tablet-alt",
                    Title = "REFUND POLICY",
                    Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
                    ShipId = 1
                });

            #region HasData Another Way
            //modelBuilder.Entity("Ship", b => {
            //    b.HasData(
            //    new Ship
            //    {
            //        Id = 1,
            //        Image = "about.webp",
            //        AltImage = "This is a photo",
            //        Link = "https://vimeo.com/45830194",
            //        Header = "Better Way to Ship Your Products",
            //        Description = "But nothing the copy said could convince her and so it didn’t take long until a few insidious Copy Writers ambushed her, made her drunk with Longe and Parole and dragged her into their agency, where they abused her for their."
            //    });
            //});
            //modelBuilder.Entity("ShipItem", b =>
            //{
            //    b.HasData(
            //    new ShipItem
            //    {
            //        Id = 1,
            //        Icon = "fas fa-tablet-alt",
            //        Title = "REFUND POLICY",
            //        Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
            //        ShipId = 1
            //    });
            //    b.HasData(
            //    new ShipItem
            //    {
            //        Id = 2,
            //        Icon = "fas fa-tablet-alt",
            //        Title = "REFUND POLICY",
            //        Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
            //        ShipId = 1
            //    }); 
            //    b.HasData(
            //    new ShipItem
            //    {
            //        Id = 3,
            //        Icon = "fas fa-tablet-alt",
            //        Title = "REFUND POLICY",
            //        Content = "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic",
            //        ShipId = 1
            //    });
            //});
            #endregion

            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    LeftVerticalText = "BEST ECOMMECE ONLINE SHOP",
                    SupHeader = "WINKEL ECOMMERCE SHOP",
                    Header = "A Thouroughly <b>Modern</b> Woman",
                    Description = "A small river named Duden flows by tehir place and supplies it with the necessary regelialia. It is a paradisematic country.",
                    Image = "bg_2.webp",
                    AltImage = "This is girl photo"
                },
                new Slider
                {
                    Id = 2,
                    LeftVerticalText = "WINKEL ECOMMERCE SHOP",
                    SupHeader = "ESTABLISHED SICNE 2000",
                    Header = "Catch Your Own\r\n    <pre><b>Stylish & Look</b></pre>",
                    Description = "A small river named Duden flows by tehir place and supplies it with the necessary regelialia. It is a paradisematic country.",
                    Image = "bg_1.webp",
                    AltImage = "This is boy photo"
                });
        }
    }
}
