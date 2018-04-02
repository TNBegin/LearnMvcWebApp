/*************************************************************************************
 * CopyRight (c) 2017 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 * 机器名称：PC-YHT
 * 公司名称：
 * 命名空间：CodeFirstWebApp.Models
 * 文件名：Order
 * 版本号：V1.0.0.0
 * 唯一标识吗：b9d34e22-57e5-40c0-abf9-9ab5031f0223
 * 当前用户与名：PC-YHT
 * 创建人：Administrator
 * 电子邮箱：yht_wy@126.com
 * 创建时间：2017-07-29 18:39:24
 * 
 * 描述：
 * 
 * ==================================================================
 * 修改标记
 * 修改时间：2017-07-29 18:39:24
 * 修改人：Administrator
 * 版本号：V1.0.0.0
 * 描述：
 * 
 * 
 * ************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//System.ComponentModel.DataAnnotations数据注解提供的特性仅仅是Fluent API配置的一部分子集而已，所以，如果你，在数据注解中，没有找到的属性，可以使用Fluent API来配置。
using System.Linq;
using System.Web;

namespace CodeFirstWebApp.Models
{
    public class Order
    {
        /// <summary>
        /// 如果属性名字是 Id 或者是 类名+Id 就会被自动设置成主键，可以不用添加[Key]属性
        /// </summary>
        //[Key]
        public int OrderID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [StringLength(50)]
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderAmount { set; get; }

        /*通过导航属性，Code-First能够推断出，两个实体之间的关系，这个导航属性可以是简单的引用类型或者是集合类型.*/
        /// <summary>
        /// 导航属性设置成virtual，可以实现延迟加载（惰性加载指的是当第一访问导航属性的时候自动
        /// 从数据库加载相关实体。这种特性是由代理类实现的，代理类派生自实体类，并重写了导航属性。
        /// 所以我们的实体类的导航属性就必须标记为virtual）
        /// </summary>
        public virtual List<OrderDetail> OrderDetail { set; get; }
    }
}