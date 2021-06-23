using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace ProductAPI.Models
{
    public enum Type
    {
        Type1,Type2,Type3
    };
    public enum Color
    {
        Color1,Color2,Color3
    };
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Type Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get; set; }
        public double Price { get; set; }
        
        //for test purpose only
        public static List<Product> TestProducts()
        {
            Random r = new Random(100);
            var arr = new Product[300];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Product() 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Product " + (i + 1), 
                    Color = (Color)(r.Next(3)), 
                    Type = (Type)(r.Next(3)), 
                    Price = r.Next(100, 10000)
                };
            }
            return arr.ToList();
        }
    }
}
