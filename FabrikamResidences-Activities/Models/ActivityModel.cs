using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikamResidences_Activities.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy @ h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [NotMapped]
        [Display(Name="Date", Prompt = "mm/dd/yyyy [hh:mm]")]
        public string ModifyDate { get; set; }

    }
}
