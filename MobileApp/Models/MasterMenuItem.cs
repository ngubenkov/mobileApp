using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }
        public MasterMenuItem(string title, string IconSouce, Color color, Type target)
        {
            this.Title = title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = target;
        }

    }
}
