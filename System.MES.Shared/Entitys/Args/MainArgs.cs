using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Shared.Entitys.Args
{
    public class MainArgs:BindableBase
    {

        public static readonly MainArgs Instance = new Lazy<MainArgs>(() => new MainArgs()).Value;

        private string icon;
        private string title;
        private string content;
        private string color;
        private string target;
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// 触发目标
        /// </summary>
        public string Target
        {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// 左侧菜单
        /// </summary>
        public ObservableCollection<ListMenu> ListItems { get; set; }

        /// <summary>
        /// 程序的运行状态
        /// </summary>
        //  public ObservableCollection<Health> HealthList { get; set; }

        public MainArgs()
        {
            Init();
        }

        public void Init()
        {


            ListItems = new ObservableCollection<ListMenu>
            {
                new ListMenu {  Icon="Home", Title = "电点火管", },
                new ListMenu {  Icon="Home", Title = "PLC设置", }
            };

            /*HealthList = new ObservableCollection<Health>();
            HealthList.Add(new Health() { Icon = "ClockFast", Title = "产品计数 :", Content = "9", Color = "#FF0CA0FF", Target = "ToDoView" });
            HealthList.Add(new Health() { Icon = "ClockCheckOutline", Title = "合格数 :", Content = "9", Color = "#FF1ECA3A", Target = "ToDoView" });*/

        }

    }
    public class ListMenu : BindableBase
    {
        private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

    }
}
