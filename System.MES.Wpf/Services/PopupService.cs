using NewLife.Model;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Wpf.IServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace System.MES.Wpf.Services
{
    public class PopupService : IPopupService
    {
        /*private readonly IObjectContainer _objectContainer;

        public PopupService(IObjectContainer objectContainer)
        {
             _objectContainer= objectContainer;
        }*/

        public void Show(string name)
        {
            ShowDialogInit(name);
        }

        public void ShowDialogInit(string name) 
        {
            GetActiveWindow();
        }

        private static Window? GetActiveWindow()
        {
            return Application.Current.Windows.Cast<Window>().FirstOrDefault(currentWindow => currentWindow.IsActive);
        }
    }

    public interface MyWindow : IDialogWindow
    {

    }
}
