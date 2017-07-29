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
        public CodeFirstContext() : base("name=CodeFirstContext"){ }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}