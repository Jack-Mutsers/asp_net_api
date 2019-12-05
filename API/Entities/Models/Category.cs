using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("categorie")]
    public class Category
    {
        [Column("cat_id")]
        public int id { get; set; }

        [Required(ErrorMessage = "categorie name is required")]
        [Column("cat_name")]
        public string name { get; set; }
    }
}
