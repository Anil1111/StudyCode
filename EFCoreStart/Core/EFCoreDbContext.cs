using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStart.Core
{
    public class EFCoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreDbConnectionString"]
                .ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(k => k.Id);
                //TODO:������������
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                //TODO:������������
                entity.Property(p => p.Id).ValueGeneratedNever();
                //TODO:�������޸�ʵ��ʱ�ͻ��Զ�����ֵ���޸�ʵ��ʱ�ͻ��Զ�����ֵ
                entity.Property(p => p.CreateTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
                //TODO:�޸�ʵ��ʱ�ͻ��Զ�����ֵ
                entity.Property(p => p.Id).ValueGeneratedOnUpdate();
            });
        }
        public DbSet<Student> Students { get; set; }
    }
}
