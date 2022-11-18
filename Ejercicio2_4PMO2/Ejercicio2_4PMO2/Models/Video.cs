using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_4PMO2.Models
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String path { get; set; }
    }
}
