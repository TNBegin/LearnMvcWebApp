using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data;
using System.Linq;
using ModelFirstConsoleApp;

namespace ModelFirstConsoleApp
{
    class Program
    {
        /*注：从模型更新数据库时，生成的Sql语句将会先判断是否存在表，存在的话将会删除重建（更新前做好数据备份）。
         * 1.在生产环境下操作模型更新需谨慎而行之，确认在测试环境实际开发中执行没问题了。
         * 2.进行数据库备份（开启增量备份最佳），然后在执行Sql。执行Sql出现问题只能恢复数据库，如MySql中可以根据日志中的时间点和位置进行恢复。
         * 3.如果可以把改动地方的Sql语句单独抠出来执行，如若改动某个实体的字段属性可以直接
           
        */
        static void Main(string[] args)
        {
            //实体属性string 长度修改
            AddTestData();
            Console.WriteLine("查询如下：");
            ShowOrderList();
            Console.ReadKey();
        }

        static void AddTestData() {
            using (ModelFirstModelContainer db=new ModelFirstModelContainer())
            {

                try
                {
                    Customer _Customer = new Customer { Id = Guid.NewGuid(), Name = "muyi", Age = 27, ComepanyName = "quandier", Telphone = "18730912482",Sex="m" };
                    Order _Order1 = new Order { OrderNo = "201707280001", Amount = 15, CreateTime = DateTime.Now, CustomerId = _Customer.Id };
                    Order _Order2 = new Order { OrderNo = "201707280002", Amount = 15, CreateTime = DateTime.Now, Customer = _Customer };
                    Product _Product = new Product { Name = "华为荣耀8", Price = 2599, Weight = 1, Customer = new List<Customer>() { _Customer } };

                    #region 方法一
                    db.Customer.Add(_Customer);
                    db.Product.Add(_Product);
                    db.Order.Add(_Order1);
                    db.Order.Add(_Order2);
                    #endregion

                    #region 方法二
                    //db.Customer.Attach(_Customer);
                    //db.Entry(_Customer).State = EntityState.Added;

                    //db.Order.Attach(_Order1);
                    //db.Entry(_Order1).State = EntityState.Added;

                    //db.Order.Attach(_Order2);
                    //db.Entry(_Order2).State = EntityState.Added;

                    //db.Product.Attach(_Product);
                    //db.Entry(_Product).State = EntityState.Added;
                    #endregion

                    if (db.SaveChanges() > 0)
                    {
                        Console.WriteLine("add records success !");
                    }
                    else
                    {
                        Console.WriteLine("add records failed !");
                    }
                }
                catch (DbEntityValidationException e)
                {
                    throw;
                }
               
            }

        }

        static void ShowOrderList() {
            using (ModelFirstModelContainer db =new ModelFirstModelContainer())
            {
                try
                {
                    #region 方法一 Linq
                    /*通过导航属性关联*/
                    //var _orderList = (from o in db.Order
                    //                  where o.Customer.Name == "muyi"
                    //                  select o).ToList<Order>(); 

                    /*通过Join 关联*/
                    var _orderList = (from o in db.Order
                                      join c in db.Customer on o.CustomerId equals c.Id
                                      where c.Name.Equals("muyi")
                                      select o).ToList();

                    #endregion

                    #region 方法二 Lambda
                    /*通过导航属性关联*/
                    //var _orderList = db.Order.Where(o => o.Customer.Name == "muyi").ToList();

                    /*通过Join 关联*/
                    //var _orderList = db.Order.Join(db.Customer, o => o.CustomerId, c => c.Id, (o, c) => new { o, c }).Where(o=>o.c.Name.Equals("muyi")).Select(o => o.o).ToList();
                    #endregion

                    Console.WriteLine("muyi订单如下：");
                    _orderList.ForEach(o=>Console.WriteLine(string.Format("订单号：{0}, 订单金额：{1}, 创建时间：{2}",o.OrderNo,o.Amount,o.CreateTime)));

                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }
    }


}
