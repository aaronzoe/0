using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class Order
    {
        [AutoIncrement]
        public int ID { get; set; }

        public string OrderID { get; set; }

        public string Khqd { get; set; }
        public string Khmc { get; set; }
        public string Lxr { get; set; }
        public string Lxdh { get; set; }
        public DateTime Yjfhsj { get; set; }
        public string Shdz { get; set; }
        public string UserID { get; set; }
        public string Zt { get; set; }
        public decimal Shje { get; set; }
        public string Remark { get; set; }
        public bool NeedSp { get; set; }
        public IList<OrderGoods> OrderGoodses { get; set; }
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateAt { get; set; }
        public bool Del { get; set; }


        public decimal Dk { get; set; }
        public decimal Yf { get; set; }
        public decimal Zje { get; set; }
        public decimal Fy { get; set; }

        public Int64 Xh { get; set; }

    }
    public class OrderGoods
    {
              [AutoIncrement]
        public int ID { get; set; }
        public string OrderID { get; set; }
        public int GoodsID { get; set; }


        public string Taste { get; set; }
        public int Num { get; set; }
        public decimal Price { get; set; }
         public decimal Amount { get; set; }

        public string Remark { get; set; }
         /// <summary>
         /// 运费
         /// </summary>
         public decimal Fare { get; set; }
         /// <summary>
         /// 实付金额
         /// </summary>
         public decimal Shje { get; set; }

     /// <summary>
     /// 重量
     /// </summary>
     public decimal Weight { get; set; }
         /// <summary>
         /// 搭赠
         /// </summary>
     public int Dz { get; set; }

         public Int64 Xh { get; set; }
         public string Category { get; set; }
         public string Name { get; set; }
         public string Code { get; set; }
         public string Size { get; set; }
         public string NewName { get; set; }
    }
}