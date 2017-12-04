using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroService.Models
{
    public class Order
    {
        //model porudzbine (id, order date, delivery date, delivery address, delivery zip code,  delivery city, delivery country, note, userid, price, quantity

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string ZipCode { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountry { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }



    }
}