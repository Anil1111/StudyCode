﻿using EFStudy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EFStudy.Model.Order;

using EFStudy.Conventions;
using System.Text.RegularExpressions;
using EFStudy.Attributes;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFStudy.Core
{
    public class EfDbContext:DbContext
    {
        public EfDbContext():base("name=ConnectionString")
        {
            //禁用数据库初始化策略
            //Database.SetInitializer<EfDbContext>(null);
            //如果数据库不存在，就创建
            //Database.SetInitializer(new CreateDatabaseIfNotExists<EfDbContext>());
            //总是创建数据库，无论是否存在
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfDbContext>());
            //如果EF检测到数据模型发生了改变，将更新模型
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
        }
        //public DbSet<Blog> Blogs { get; set; }

        //public DbSet<User> User { get; set; }
        //public DbSet<BillingDetail> BullingDetails { get; set; }
        public DbSet<Customer> Customer { get;set;}

        public DbSet<Course> Course { get; set; }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(type => !String.IsNullOrEmpty(type.Namespace)).Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //modelBuilder.Entity<Blog>().ToTable("Blogs");
            //modelBuilder.Entity<Blog>().HasKey(k => k.Id).Property(p=>p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<Blog>().Property(p => p.Name).HasMaxLength(50);
            //TODO:乐观并发Token
            //modelBuilder.Entity<Blog>().Property(p => p.Name).IsConcurrencyToken();
            //TODO:乐观并发行版本
            //modelBuilder.Entity<Blog>().Property(p => p.Char).IsRowVersion();
           // modelBuilder.Entity<Blog>().Property(p => p.CreatedTime).IsOptional();
            //modelBuilder.Entity<Blog>().Property(p => p.Char).HasColumnType("char").HasMaxLength(11);
            //TODO:另一种实现方式
           // modelBuilder.Entity<Blog>().Property(p => p.Char).IsFixedLength();
            //TODO:如果要设置联合主键可以通过匿名对象实现
            //modelBuilder.Entity<Blog>().HasKey(k => new { Id = k.Id, BlogId = k.BlogId });
            //TODO:通过ComplexType显示指定复杂类型
            //modelBuilder.ComplexType<Model.Address>();
            //TODO:配置映射
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<BillingDetail>().Map<BankAccount>(m => m.Requires("BillingDetailType").HasValue(1)).Map<CreditCard>(m => m.Requires("BillingDetailType").HasValue(2));
            //modelBuilder.Entity<Order>().ToTable("Orders");
            //modelBuilder.ComplexType<Address>();
            //modelBuilder.Conventions.Add<CustomKeyConvention>();
            //modelBuilder.Conventions.Add<DateTime2Convention>();
            ////TODO: 利用Properties方法查找模型全局处理
            //modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(10, 2));
            ////TODO:对多个属性进行相同的约定配置时，最后一个约定将覆盖前面所有相同的约定
            //modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(500));
            //modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(250));
            ////TODO:自定义类型约定
            //modelBuilder.Types().Configure(c => c.ToTable(GetTableName(c.ClrType)));
            //modelBuilder.Properties().Where(x => x.GetCustomAttributes(false).OfType<IsUnicode>().Any()).Configure(c => c.IsUnicode(c.ClrPropertyInfo.GetCustomAttribute<IsUnicode>().Unicode));
            ////简化
            //modelBuilder.Properties().Having(x => x.GetCustomAttributes(false).OfType<IsUnicode>().FirstOrDefault()).Configure((config, att) => config.IsUnicode(att.Unicode));
        }
        /// <summary>
        /// 自定义类型约定
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTableName(Type type)
        {
            var result = Regex.Replace(type.Name, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);
            return result.ToLower();
        }
    }





}