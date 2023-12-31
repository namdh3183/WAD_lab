﻿namespace lab1rework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsdsds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KHACHHANG", "Taikhoan", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.KHACHHANG", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KHACHHANG", "Email", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.KHACHHANG", "Taikhoan", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
