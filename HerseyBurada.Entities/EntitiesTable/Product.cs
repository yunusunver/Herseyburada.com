using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.Entities.EntitiesTable
{
    //Ürünler tablosunun oluşturulduğu kısım.Validationların tanımlandığı yer.

    [Table("Product")]
    public class Product:BaseEntity
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
        }
        [Required(ErrorMessage ="Ürün ismi boş geçilemez.")]
        public string ProductName{ get; set; }
        [Required(ErrorMessage = "Ürün açıklaması boş geçilemez.")]
        public string ProductDescripion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Image { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        //Category ile  1-m ilişki tanımladık.
        public virtual Category Categories { get; set; }
    }
}
