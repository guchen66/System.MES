using Furion.DependencyInjection;
using SqlSugarDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SqlSugarDB.Dto
{
    public interface IUserProvider:ITransient
    {
        Task<List<User>> GetListAsync();
        Task<long> AddReturnId(Father input);
    }

    public class UserProvider : Repository<User>, IUserProvider
    {
        public override async Task<List<User>> GetListAsync()
        {
            var list= await  base.GetListAsync();
            return list;
        }

        public async Task<long> AddReturnId(Father input)
        {
            var dataTemp = input.Adapt<Sum>();//实体转换
          //  var entity = await InsertReturnEntityAsync(dataTemp);//插入数据
          //  await RefreshCache();//刷新缓存
            return 1;
        }

    }

    public class Father
    {

    }

    public class Sum:Father
    {

    }

    public static class TypeAdapter
    {
        public static TDestination Adapt<TDestination>(this object source)
        {
           // return source.Adapt<TDestination>(TypeAdapterConfig.GlobalSettings);
           return (TDestination)source;
        }
    }
}
