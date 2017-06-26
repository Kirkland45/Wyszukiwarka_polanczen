using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BindModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
    }
}