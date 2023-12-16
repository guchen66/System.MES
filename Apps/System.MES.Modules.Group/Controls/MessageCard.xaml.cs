using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace System.MES.Modules.Group.Controls
{
    /// <summary>
    /// MessageCard.xaml 的交互逻辑
    /// </summary>
    public partial class MessageCard
    {
        public static readonly DependencyProperty HeadUriProperty = DependencyProperty.Register("HeadUri", typeof(Uri), typeof(MessageCard), new PropertyMetadata(default(Uri)));
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageCard), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty AuthorProperty = DependencyProperty.Register("Author", typeof(string), typeof(MessageCard), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(DateTime), typeof(MessageCard), new PropertyMetadata(default(DateTime)));


        public MessageCard()
        {
            InitializeComponent();
        }


        public Uri HeadUri
        {
            get => (Uri)GetValue(HeadUriProperty);
            set => SetValue(HeadUriProperty, value);
        }

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public string Author
        {
            get => (string)GetValue(AuthorProperty);
            set => SetValue(AuthorProperty, value);
        }

        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }
    }
}
