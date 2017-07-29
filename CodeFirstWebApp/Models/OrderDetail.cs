/*************************************************************************************
 * CopyRight (c) 2017 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 * 机器名称：PC-YHT
 * 公司名称：
 * 命名空间：CodeFirstWebApp.Models
 * 文件名：OrderDetail
 * 版本号：V1.0.0.0
 * 唯一标识吗：c76ef788-9708-43e8-ac8b-142b21baee29
 * 当前用户与名：PC-YHT
 * 创建人：Administrator
 * 电子邮箱：yht_wy@126.com
 * 创建时间：2017-07-29 18:40:04
 * 
 * 描述：
 * 
 * ==================================================================
 * 修改标记
 * 修改时间：2017-07-29 18:40:04
 * 修改人：Administrator
 * 版本号：V1.0.0.0
 * 描述：
 * 
 * 
 * ************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstWebApp.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        /// <summary>
        /// 订单明细单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 订单明细数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 外键，如果属性名和Order主键名称一致，默认会当成外键，可以不加ForeignKey特性
        /// 注：ForeignKey里面的值要和导航属性的名称一致
        /// </summary>
        [ForeignKey("Order")]
        public int OrderId { get; set; }


        public virtual Order Order { get; set; }
    }
}