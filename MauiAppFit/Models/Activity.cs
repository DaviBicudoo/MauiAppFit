using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiAppFit.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public double? Weight { get; set; }
        public string? Observations { get; set; }
    }
}
