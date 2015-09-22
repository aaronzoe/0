namespace WebService.Domain
{

    public class ReportWeek : EntityBase
    {

        public string UserID { get; set; }


        /// <summary>
        /// 汇报人
        /// </summary>

        public string Hbr { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 本月销售目标
        /// </summary>
        public string Mb1 { get; set; }

        /// <summary>
        /// 本周销售目标
        /// </summary>
        public string Mb2 { get; set; }

        /// <summary>
        /// 本周渠道开发计划
        /// </summary>
        public string Qd { get; set; }

        /// <summary>
        /// 重点促销
        /// </summary>
        public string Zdcx { get; set; }

        /// <summary>
        /// 领导批示
        /// </summary>
        public string Ldps { get; set; }
        //  [Sqlserver.Column("StartTime", "datetime", "", false)]

        //public DateTime StartTime { get; set; }

        public string Gzjz { get; set; }

          public string Bt { get; set; }

    }
}