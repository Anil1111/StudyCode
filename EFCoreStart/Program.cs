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
                //TODO:EFCode不知道是否要创建，所以要手动去创建   
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

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
                //    Introduce = "轻量级、可扩展、跨平台",
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
                //var blogs = context.Blogs.Include(d => d.Post).ToList();

                //var blog = context.Blogs.Include(d => d.Post).IgnoreQueryFilters().AsNoTracking().ToList();
                //var blogId = 1;
                //var posts = context.Set<Post>().Where(d => EF.Property<int>(d, "BlogId") == blogId);
                //var tags = new[]
                //{
                //    new Tag{Text="1"},
                //    new Tag{Text="2"},
                //    new Tag{Text="3"},
                //    new Tag{Text="4"},
                //    new Tag{Text="5"},
                //};
                //var posts = new[]
                //{
                //    new Post{Name="1"},
                //    new Post{Name="2"},
                //    new Post{Name="3"},
                //    new Post{Name="4"},
                //    new Post{Name="5"},
                //};

                //context.AddRange(new PostTag { Posts = posts[0], Tags = tags[0] },
                //    new PostTag { Posts = posts[1], Tags = tags[1] },
                //    new PostTag { Posts = posts[2], Tags = tags[2] },
                //    new PostTag { Posts = posts[3], Tags = tags[3] },
                //    new PostTag { Posts = posts[4], Tags = tags[4] });
                //context.SaveChanges();

                //var postss = context.Set<Post>().Include("PostTags.Tag").ToList();

                //context.Payments.Add(new CashPayment {Amount = 2M, Name = "Tom"});
                //context.Payments.Add(new CashPayment {Amount = 1000M, Name = "Jim"});

                //context.Payments.Add(new CreditcardPayment()
                //{
                //    Amount = 200000,
                //    Name = "招商银行",
                //    CreditcardNumber = "041647181912"
                //});
                //context.SaveChanges();

                //var payments = context.Payments.ToList();
                //foreach (var payment in payments)
                //{
                //    Console.WriteLine($"{payment.Name}{payment.Amount}{payment.GetType().Name}");
                //}

                //var payments = context.Payments.ToList();
                //foreach (var payment in context.Payments.OfType<CreditcardPayment>())
                //{
                //    Console.WriteLine($"{payment.Name}{payment.Amount}{payment.GetType().Name}");
                //}
                //TODO: 当使用主键查询时使用Find方法性能会更好
                //var blog = context.Blogs.Find(1);
                //var blogs = context.Blogs.FirstOrDefault(d => d.Id == 1);
                //TODO:复合主键
                //var productCategory = context.Blogs.Find(1, 1);
                //TODO:利用Find或者FindAsync方法不能进行饥饿加载(Include),但是我们任然能够通过上下文的Entry方法中的Navigations属性加载导航属性实现饥饿加载
            
                
                //var student = context.Students.Find(Convert.ToInt32(3));
                //foreach (var navigation in context.Entry(student).Navigations)
                //{
                //    navigation.Load();
                //}

                //TODO:在继承映射TPH模式中，可以用OfType方法转换为具体类，所以此方法与查询运算符等值条件等价
                //var patments = context.Payments.OfType<CashPayment>();
                //Console.WriteLine(patments.FirstOrDefault()?.Name);
                //TODO:也可以用Cast进行转换与OfType的区别是，Cast将翻译成In子句
                //var payments = context.Payments.Cast<CashPayment>();
                //Console.WriteLine(payments.FirstOrDefault()?.Name);
                //TODO:EF Code不支持使用OfType和Cast转换原始类型
                //var paymentss = context.Payments.Select(d => d.PaymentId).OfType<string>();
                //Console.WriteLine(paymentss);
                //TODO:C# 中可以使用if和as来进行类型转换。如果一个对象是某个类型或是其父类型，就返回true否则返回false，Is永远不会抛出异常，As会
                //TODO:Is进行类型转换等同于Cast在sql中都会翻译成in子句
                var payments = context.Payments.Where(d => d is CashPayment);
                Console.WriteLine(payments.FirstOrDefault()?.Name);
                //TODO:调用Select会翻译成Select子句，投影不仅支持实体，同时支持匿名函数
                var paymentss = context.Payments.Select(d => d.Name + " ");
                Console.WriteLine(paymentss.FirstOrDefault());

            }
        }
    }
}
