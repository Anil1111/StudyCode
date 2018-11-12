using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;
using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreStart
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreDbContext())
            {
                //TODO:EFCode不知道是否要创建，所以要手动去创建   
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //TODO:手动调用EntityFramework Core内置API创建
                //RelationalDatabaseCreator databaseCreator =
                //    (RelationalDatabaseCreator) context.Database.GetService<IDatabaseCreator>();
                //databaseCreator.CreateTables();
                //var student = context.Students.FirstOrDefault();

                //var s = new Student()
                //{
                //    Age = 1,
                //    Decimal = 1,
                //    Double = 1,
                //    Float = 1,
                //    CreateTime = DateTime.Now,
                //    Name = "chenjie"
                //};
                //context.Students.Add(s);
                //context.SaveChanges();

                //s.Name = "chenjielove";
                //context.SaveChanges();

                //context.Set<Customer>().AddRange(
                //    new Customer() { Name = "111"},
                //    new Customer() { Name = "222"}
                //    );
                //context.SaveChanges();


                context.Blogs.Add(new Blog("http://www.cnblogs.com") {Name = "chenjie"});
                context.SaveChanges();
                foreach (var blog in context.Blogs)
                {
                    Console.WriteLine($"{blog.Id}{blog.Name}{blog.Url}");
                }

            }
           
           


        }
    }
}
