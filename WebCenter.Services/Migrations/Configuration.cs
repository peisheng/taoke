using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using WebCenter.Entities;

namespace WebCenter.Services.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DataCenter>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataCenter context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var syshelps = new[]{
            //           new SysHelp {  Title = "DbSet<T>.AddOrUpdate()���Լ�¼��", Content = "Ĭ�����������жϸü�¼�Ƿ���ڣ���������Ӹ��¡�" },
            //           new SysHelp {  Title = "�¼ӹ���ģ�鼰���ݿ���Configuraion.cs�н������", Content = "Ĭ�����������жϸü�¼�Ƿ���ڣ���������Ӹ��¡�" } 
            //    };

            //context.SysHelps.AddOrUpdate(a => new { a.Title }, syshelps);
        }
    }
}