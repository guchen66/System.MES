
using Microsoft.Extensions.Options;
using System.MES.Core.Const;
using System.MES.Shared.Entitys.Args;
using System.MES.Wpf.IServices;
using System.Windows.Controls.Primitives;

namespace System.MES.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainArgs appData { get; set; } = MainArgs.Instance;
        private readonly AppInfoOptions _appInfo;
        private readonly IPopupService _popupService;
        IDialogService _dialogService;
        IOptions<AppInfoOptions> _options;
        public MainViewModel(IOptions<AppInfoOptions> options, IPopupService popupService , IDialogService dialogService)
        {
            _dialogService = dialogService;
            _popupService = popupService;
            _appInfo = options.Value;       //在数据层验证
            InitializingCommand = new RelayCommand(ExecuteLoading);
            NavigateCommand = new DelegateCommand<string>(ExecuteNavicate);
            SettingCommand = new DelegateCommand(OpenSetting);
        }

        private int _currentPageIndex;
        public int CurrentPageIndex
        {
            get => _currentPageIndex;
            set
            {
                SetProperty(ref _currentPageIndex, value);
            }
        }

        public ICommand SettingCommand { get; set; }
        //ListItems

        private void ExecuteLoading() 
        {
           // appData.ListItems.Clear();
            var info1 = $@"名称：{_appInfo.Name}，
                      版本：{_appInfo.Version}，
                      公司：{_appInfo.Company}";

        }

        public void OpenSetting()
        {
            _popupService.Show("name");
        }

        public void ExecuteNavicate(string path)
        {
           
            switch (path)
            {
                case "首页":
                    CurrentPageIndex = 0;
                    break;
                case "设置":
                    CurrentPageIndex = 1;
                    break;
            }
        }

        private DelegateCommand<ListMenu> navigateCommand;
        public DelegateCommand<ListMenu> NavigateCommand2 =>
            navigateCommand ?? (navigateCommand = new DelegateCommand<ListMenu>(ExecuteNavigateCommand));

        private void ExecuteNavigateCommand(ListMenu obj) 
        {
           /* switch (obj)
            {
                case obj.Title:
                    CurrentPageIndex = 0;
                    break;
                case "设置":
                    CurrentPageIndex = 1;
                    break;
            }*/
        }
        public ICommand InitializingCommand { get; set; }
        public ICommand NavigateCommand { get; set; }
        private void Navigate(string navigatePath)
        {
           /* if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath, arg =>
                {
                    _navigationJournal = arg.Context.NavigationService.Journal;
                });*/

        }
    }
}
