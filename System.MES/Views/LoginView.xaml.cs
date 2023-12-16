using Furion;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.ViewModels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace System.MES.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly LoginViewModel _loginViewModel;
        public LoginView(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            InitializeComponent();
            this.DataContext= loginViewModel;
        }
        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }*/

            this.DragMove();
        }

    }
}
