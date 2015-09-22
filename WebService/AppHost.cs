using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.FluentValidation.Results;
using ServiceStack.Formats;
using ServiceStack.Logging;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.Razor;
using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Validation;
using WebService.Domain;
using WebService.ServiceInterface;

namespace WebService
{
    public class AppHost : AppHostBase
    {
        public static ILog Log = LogManager.GetLogger(typeof(AppHost));
        public AppHost() : base("KlklWebService", typeof(MyService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            Plugins.Add(new RazorFormat());
            Plugins.Add(new SwaggerFeature());
            Plugins.Add(new MetadataFeature());
            Plugins.Add(new RequestLogsFeature()
            {
                RequiredRoles = null,
                
            });
            Plugins.Add(new CsvFormat());
            Plugins.Add(new AutoQueryFeature()
            {
                MaxLimit = 100,
            });

            Plugins.Add(
                new CorsFeature(
                    (ConfigurationManager.AppSettings.Get("AllowOriginWhitelist") ?? "").Split(new char[] { ',' })));
            //Plugins.Add(new ValidationFeature
            //{
            //    ErrorResponseFilter = CustomValidationError
            //});
            //   Plugins.Add(new RequestLogsFeature{});

            SetConfig(new HostConfig { DebugMode = true });
            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json,
                EnableFeatures = Feature.All.Remove(Feature.Html),
                GlobalResponseHeaders = { { "Access-Control-Allow-Origin", "*" }, },
                

            });
            LogManager.LogFactory=new NullLogFactory(true);
            //SetConfig(new HostConfig
            //{
            //    AddMaxAgeForStaticMimeTypes = 
            //    {
            //        {"image/png", TimeSpan.FromHours(10)}
            //    }
            //});
            JsConfig.ExcludeTypeInfo = true;
            JsConfig<DateTime>.SerializeFn =
                time => new DateTime(time.Ticks, DateTimeKind.Local).ToString("yyyy-MM-dd HH:mm:ss");
   
            //   JsConfig.DateHandler =DateHandler.ISO8601;
            this.ServiceExceptionHandlers.Add((httpReq, request, exception) =>
            {
                var builder = new StringBuilder();
                builder.AppendLine(string.Format("{0}{1}", DateTime.Now, httpReq.AbsoluteUri));
                builder.AppendLine(request.ToJsv());
                builder.AppendLine(exception.Message);
                builder.AppendLine(exception.StackTrace);
                Log.Error(builder);
                return DtoUtils.CreateErrorResponse(request, exception);
            });
            this.UncaughtExceptionHandlers.Add((req, res, operationName, ex) =>
            {
                var builder = new StringBuilder("UncaughtException\r\n");
                builder.AppendLine(string.Format("{0}{1}", DateTime.Now, req.AbsoluteUri));
                builder.AppendLine(req.Dto.ToJson());
                builder.AppendLine(ex.Message);
                builder.AppendLine(ex.StackTrace);
                Log.Error(builder);
                res.Write("Error: {0}: {1}".Fmt(ex.GetType().Name, ex.Message));
                res.EndRequest(true);
            });


            #region 数据库连接创建

            OrmLiteConnectionFactory dbFactory = null;

            dbFactory = new OrmLiteConnectionFactory(
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString,
                SqlServerOrmLiteDialectProvider.Instance)
            {
#if DEBUG
                ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
#endif
            };

            #endregion
      
            container.Register<IDbConnectionFactory>(dbFactory);


      

            #region Validators
            //所有的验证方法放在一个类,这里不需要再加了
         //   container.RegisterValidators(typeof(ActivityFullReduceAddValidator).Assembly);
            #endregion

            JsConfig.DateHandler = DateHandler.ISO8601;
            SetConfig(new HostConfig()
            {
                EnableFeatures = Feature.All.Remove(Feature.Metadata),
            });

            var appSettings = new AppSettings();

            container.Register(appSettings);

            Plugins.Add(new RegistrationFeature());
            var redisFactory = new PooledRedisClientManager("localhost")
            {
                ConnectTimeout = 100,
                //...
            };
            
    //        container.Register<IDbConnectionFactory>(
    //new OrmLiteConnectionFactory(":memory:",ServiceStack.OrmLite.SqlServer.SqlServerOrmLiteDialectProvider());
            container.Register<IRedisClientsManager>(c => redisFactory
               );
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register(appSettings);
            var ormLiteAuthRepository = new OrmLiteAuthRepository(dbFactory);
            ormLiteAuthRepository.InitSchema();
            container.Register<IUserAuthRepository>(c => ormLiteAuthRepository);
            Plugins.Add(new AuthFeature(
                () => new AuthUserSession(),
                new IAuthProvider[] { new CustomCredentialsAuthProvider() }, "/views/login/login.html"
                ));
            AlertTable(dbFactory);
        }

        private void AlertTable(OrmLiteConnectionFactory dbFactory)
        {
            var dbcon = dbFactory.OpenDbConnection();
            dbcon.CreateTable<Approval>();
            dbcon.CreateTable<Box>();
            dbcon.CreateTable<Category>();
            dbcon.CreateTable<Customer>();
            dbcon.CreateTable<FamilyTree>();
            dbcon.CreateTable<Goods>();
            dbcon.CreateTable<GoodsMaterial>();
            dbcon.CreateTable<Material>();
            dbcon.CreateTable<MaterialType>();
            dbcon.CreateTable<Order>();
            dbcon.CreateTable<Report>();
            dbcon.CreateTable<OrderGoods>();
            dbcon.CreateTable<ReportWeek>();
            dbcon.CreateTable<Taste>();
            dbcon.CreateTable<UserSign>();
        }
        //private object CustomValidationError(ValidationResult validationResult, object errorDto)
        //{
        //    var firstError = validationResult.Errors[0];
        //    var dto = new BaseResponse.ExceptionResponse()
        //    {
        //        Code = 20000,
        //        ErrorMessage = firstError.ErrorMessage
        //    };
        //    return dto;
        //    //Ensure HTTP Clients recognize this as an HTTP Error
        //    //    return new HttpError(dto, HttpStatusCode.BadRequest, dto.code, dto.error);
        //}
    }
}