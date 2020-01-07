using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("component")]
    public class Component
    {
        [Column("comp_id")]
        public int id { get; set; }

        [Required(ErrorMessage = "component name is required")]
        [StringLength(100, ErrorMessage = "component name can't be longer than 500 characters")]
        [Column("comp_name")]
        
        public string name { get; set; }

        [Required(ErrorMessage = "categorie id is required")]
        [Column("cat_id")]
        public int Categoryid { get; set; }

        public int value { get; set; }

        public string ip_adress { get; set; }

        public int arduino_id { get; set; }

        [Column("alarm_status")]
        public bool status { get; set; }
    }
}
