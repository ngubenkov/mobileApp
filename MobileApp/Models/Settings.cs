using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Settings
    {
        [PrimaryKey]
        public int Id { get; set; }
        public bool switch1 { get; set; }
        public bool switch2 { get; set; }
    }
}
