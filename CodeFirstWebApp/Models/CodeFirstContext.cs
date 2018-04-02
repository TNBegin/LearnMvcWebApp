/*************************************************************************************
 * CopyRight (c) 2017 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 * 机器名称：PC-YHT
 * 公司名称：
 * 命名空间：CodeFirstWebApp.Models
 * 文件名：CodeFirstContext
 * 版本号：V1.0.0.0
 * 唯一标识吗：cae1912d-b3b9-4841-853a-1004cb541303
 * 当前用户与名：PC-YHT
 * 创建人：Administrator
 * 电子邮箱：yht_wy@126.com
 * 创建时间：2017-07-29 18:42:19
 * 
 * 描述：
 * 
 * ==================================================================
 * 修改标记
 * 修改时间：2017-07-29 18:42:19
 * 修改人：Administrator
 * 版本号：V1.0.0.0
 * 描述：
 * 
 * 
 * ************************************************************************************/
 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstWebApp.Models
{
    public class CodeFirstContext : DbContext
    {
        //3种数据库初始化方式
        ///// <summary>
        ///// 1.创建数据库命名方式：{Namespace}.{Context class name}
        ///// </summary>
        //public CodeFirstContext() : base() { }

        ///// <summary>
        ///// 2.指定数据库的名字在base构造器中；自定义数据库名：ModelFistDB
        ///// </summary>
        //public CodeFirstContext() : base("ModelFistDB") { }

        ///// <summary>
        ///// 3.1连接字符串
        ///// </summary>
        //public CodeFirstContext() : base("CodeFirstContext"){ }

        /// <summary>
        /// 3.2连接字符串
        /// </summary>
        public CodeFirstContext() : base("name=CodeFirstContext") { }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        ///// <summary>
        ///// 当模型发生改变的时候，就删掉重新创建数据库。
        ///// </summary>
        ///// <param name="modelBuilder"></param>
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    这里面配置领域类实体，通过使用Fluent API
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodeFirstContext>());

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}