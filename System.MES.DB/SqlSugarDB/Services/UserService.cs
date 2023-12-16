using Furion;
using SqlSugar;
using SqlSugarDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarDB.Services
{
    public class UserService
    {
        ISqlSugarClient db;
        public UserService(ISqlSugarClient db)
        {
            this.db = db;
        }

        public List<User> QueryList()
        {
         //   var s = App.GetService<ISqlSugarClient>();
            return db.Queryable<User>().ToList();

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<User> QueryUserToPage(int pageIndex,int pageSize,ref int totalCount)
        {
            return db.Queryable<User>().ToPageList(pageIndex,pageSize,ref totalCount);

        }
    }

    public class UserRepository:Repository<User>
    {
        public void Query()
        {
            var data1 = base.GetById(1);
        }
    }
}
