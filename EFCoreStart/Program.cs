using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;
using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore;
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
                //TODO:EFCode��֪���Ƿ�Ҫ����������Ҫ�ֶ�ȥ����   
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //TODO:�ֶ�����EntityFramework Core����API����
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


                //context.Blogs.Add(new Blog("http://www.cnblogs.com") {Name = "chenjie"});
                //context.SaveChanges();
                //foreach (var blog in context.Blogs)
                //{
                //    Console.WriteLine($"{blog.Id}{blog.Name}{blog.Url}");
                //}

                //var student=new Student()
                //{
                //    Age=1,
                //    Name = "chenjie",
                //    CreateTime = DateTime.Now
                //};
                //var course=new Course()
                //{
                //    Name = "EntityFramework Core",
                //    Introduce = "������������չ����ƽ̨",
                //    CreatedTime = DateTime.Now
                //};
                //student.AddCourse(course);
                //context.Students.Add(student);
                //context.SaveChanges();

                //var courses = context.Set<Course>().Where(d => EF.Property<int>(d, "StudentId") == 1).ToList();
                //var course=new Course
                //{
                //    Introduce = "EntityFramework Core 2.0",
                //    Name = "EF Core"
                //};
                //context.Entry(course).Property("CreateTime").CurrentValue = DateTime.Now;
                //context.SaveChanges();
            }
           
           


        }
    }
}
