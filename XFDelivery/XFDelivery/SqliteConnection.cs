using Shiny.IO;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XFDelivery.Models;

namespace XFDelivery
{
    public class SqliteConnection : SQLiteAsyncConnection
    {
        public SqliteConnection(IFileSystem fileSystem) : base(Path.Combine(fileSystem.AppData.FullName, "Food.db"))
        {
            var conn = this.GetConnection();
            conn.CreateTable<Tag>();
            conn.CreateTable<Item>();


        }
        public AsyncTableQuery<Tag> Tags => Table<Tag>();
        public AsyncTableQuery<Item> Items => Table<Item>();
    }
}
