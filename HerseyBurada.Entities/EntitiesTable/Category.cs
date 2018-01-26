using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.Entities.EntitiesTable
{
    //Kategori tablosunun tanımlandığı kısım.Validationları tanımlandığı yer.

    [Table("Category")]
    public class Category:BaseEntity
    {
        [Required(ErrorMessage ="Kategori boş geçilemez.")]
        public string CategoryName { get; set; }

        //Product ile 1-m ilişki tanımlanmıştır
        public virtual List<Product> Products { get; set; }
    }
}
