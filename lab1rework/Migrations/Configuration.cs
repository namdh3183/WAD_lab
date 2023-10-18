namespace lab1rework.Migrations
{
    using lab1rework.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab1rework.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(lab1rework.Models.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var lstChuDe = new List<CHUDE>();
            //lstChuDe.Add(new CHUDE
            //{
            //    MaCD=1,
            //    TenChuDe = "Cong nghe thong tin"
            //});
            //lstChuDe.Add(new CHUDE
            //{
            //    MaCD=2,
            //    TenChuDe = "Kinh te"
            //});
            //lstChuDe.Add(new CHUDE
            //{
            //    MaCD=3, 
            //    TenChuDe = "Ngoai ngu"
            //});
            //context.CHUDEs.AddRange(lstChuDe);

            //var lstNXB = new List<NHAXUATBAN>();
            //lstNXB.Add(new NHAXUATBAN
            //{
            //    MaNXB = 1,
            //    TenNXB = "Kim Dong"
            //});
            //lstNXB.Add(new NHAXUATBAN
            //{
            //    MaNXB = 2,
            //    TenNXB = "Tuoi tre"
            //});
            //lstNXB.Add(new NHAXUATBAN
            //{
            //    MaNXB = 3,
            //    TenNXB = "Thanh nien"
            //});
            //context.NHAXUATBANs.AddRange(lstNXB);


            var lstSach = new List<SACH>();
            lstSach.Add(new SACH
            {
                Tensach = "ahfjahgd",
                MaCD = 11,
                MaNXB = 10,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("D:\\Web App Development Project\\lab1rework\\lab1rework\\Images\\41z1V0zP2WL.jpg")
            });

            lstSach.Add(new SACH
            {
                Tensach = "tdrstdd",
                MaCD = 12,
                MaNXB = 11,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("D:\\Web App Development Project\\lab1rework\\lab1rework\\Images\\41z1V0zP2WL.jpg")
            });

            lstSach.Add(new SACH
            {
                Tensach = "tdgfrstdd",
                MaCD = 13,
                MaNXB = 12,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("D:\\Web App Development Project\\lab1rework\\lab1rework\\Images\\41z1V0zP2WL.jpg")
            });

            lstSach.ForEach(s => context.SACHes.AddOrUpdate(s));
            base.Seed(context);
        }
    }
}
