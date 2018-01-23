using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.Entities.EntitiesTable
{
    [Table("Category")]
    public class Category:BaseEntity
    {
        [Required(ErrorMessage ="Kategori boş geçilemez.")]
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
