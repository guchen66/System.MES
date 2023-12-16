using Furion;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarDB
{
    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        public Repository(ISqlSugarClient context = null) : base(context)//默认值等于null不能少
        {
            base.Context = App.GetService<ISqlSugarClient>();//用手动获取方式支持切换仓储
        }
    }
}
