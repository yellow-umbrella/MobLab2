using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobLab2.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Address { get; set; }
    }
}
