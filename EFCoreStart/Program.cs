using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EFCoreDbContext();
            //TODO:EFCode��֪���Ƿ�Ҫ����������Ҫ�ֶ�ȥ����   
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
            //TODO:�ֶ�����EntityFramework Core����API����
            RelationalDatabaseCreator databaseCreator =
                (RelationalDatabaseCreator) context.Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
            var student = context.Students.FirstOrDefault();




        }
    }
}
