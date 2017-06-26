using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Train
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Train Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "From: ")]
        public int From { get; set; }

        [Required]
        [Display(Name = "Destination: ")]
        public int To { get; set; }

        [Required]
        [Display(Name = "Start journey: ")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End journey: ")]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time of departure: ")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Arrival time: ")]
        public TimeSpan EndTime { get; set; }
    }
}