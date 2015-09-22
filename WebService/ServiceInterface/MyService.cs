using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using WebService.Domain;

namespace WebService.ServiceInterface
{
   
    public class MyService:Service
    {
      //  [Authenticate]
        public object Get(Test request)
        {
            var db = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, new ServiceStack.OrmLite.SqlServer.SqlServerOrmLiteDialectProvider()).Open();
            db.ExecuteSql("select top 1 * from member");
            return null;
            //using (IRedisClient redis = RedisManager.GetClient())
            //{

            //    var orderRedis = redis.As<Order>();
            //    if (request.N==0)
            //    {
            //        IList<Order> orders=new List<Order>();
            //        Random random=new Random();

            //        for (int i = 0; i < 10000; i++)
            //        {
            //            var order = new Order()
            //            {
            //                Id = orderRedis.GetNextSequence(),
            //                AreaName = "浙江",
            //                CreateAt = DateTime.Now,
            //                Del = false,
            //                Dk = random.Next(0, 10000/200),
            //                Fy = 1234,
            //                Khmc = "1123",
            //                Khqd = "asdasd",
            //                Lxdh = "asdasdasdsd",
            //                Lxr = "asdasd",
            //                NeedSp = false,
            //                OrderGoodses = new List<OrderGoods>(),
            //                OrderID = "sdfsdf",
            //                Remark = "sdfd",
            //                Shdz = "sdsdf",
            //                Shje = 123123,
            //                UserID = "123",
            //                Xh = 123,
            //                Yf = 123,
            //                Yjfhsj = DateTime.Today,
            //                Zje = 123,
            //                Zt = "123"
            //            };
            //         orders.Add(order);

            //        }
            //        orderRedis.StoreAll(orders);
            //    }
            //    if (request.N==1)
            //    {
            //        Stopwatch sw=new Stopwatch();
            //        sw.Start();
            //        for (int i = 0; i < 1; i++)
            //        {
            //            //var keys = orderRedis.sear
            //            //orderRedis.GetByIds(keys);
            //        }
            //        sw.Stop();
            //        return sw.ElapsedMilliseconds;
            //    }
            //    if (request.N == 2)
            //    {
            //        Stopwatch sw = new Stopwatch();
            //        sw.Start();
            //        for (int i = 0; i < 1; i++)
            //        {

            //            orderRedis.GetAll().Where(e => e.Dk == 2);
            //        }
            //        sw.Stop();
            //        return sw.ElapsedMilliseconds;
            //    }
            //}
            //return new object();
        }
        [Authenticate]
        public object Get(Index request)
        {
            return new object();
        }

        public object Post(Login request)
        {
            return new object();
        }

    }
    [Route("/test/{n}","Get")]
    public class Test
    {
        public int N { get; set; }
    }

    public class QueryTest
    {

    }


    [Route("/index", "Get")]
    public class Index
    {
        
    }
     [Route("/login", "Post")]
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}