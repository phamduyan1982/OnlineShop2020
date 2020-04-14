using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai10_OnlineShhop.Models
{
    [Serializable]
    public class CartItem
    {
        public  Product Product  { set; get; }
        public int Quantity { set; get; }
        
    }
}