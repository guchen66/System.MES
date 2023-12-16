using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Services.DataRepository
{
    public interface IDataRepository
    {
        T Get<T>(string path = null, bool isGlobal = false) where T : INotifyPropertyChanged;

        void Save(object data);
    }
}
