using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("categorie")]
    public class Categorie
    {
        [Key]
        public int cat_id { get; set; }

        [Required(ErrorMessage = "categorie name is required")]
        public string cat_name { get; set; }
    }
}
