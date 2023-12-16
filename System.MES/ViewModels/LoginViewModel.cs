
using Furion.TaskQueue;
using SqlSugarDB.Dto;
using SqlSugarDB.Models;
using System.MES.Core.Services.LoginSign;
using System.MES.Core.Services.LoginSign.Dtos;
using System.MES.Shared.Entitys.Args;

namespace System.MES.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        #region 字段
        public LoginArgs loginArgs { get; set; } = LoginArgs.Instance;
        private readonly ILoginService _loginService;
        private readonly IRegionNavigationJournal _navigationJournal;//导航日志，上一页，下一页
        private readonly IRegionManager _regionManager;//区域管理


        // IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;

        private readonly ISnackbarMessageQueue _snackbarMessageQueue;
        private readonly IConfiguration _configuration;
        private readonly IDialogService _dialogService;
        private readonly ISqlSugarClient db;
        #endregion

        #region 属性

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty<string>(ref _userName, value); }
        }
        private string _passWord;

        public string PassWord
        {
            get { return _passWord; }
            set { SetProperty<string>(ref _passWord, value); }
        }

        #endregion

        public LoginViewModel([FromServices]IConfiguration configuration,ISqlSugarClient db,ILoginService loginService)
        {

            _configuration = configuration;
            _loginService = loginService;

            InitializingCommand = new RelayCommand(ExecuteLoading);
            LoginCommand = new RelayCommand(ExecuteLogin);
            CancelCommand = new RelayCommand(ExecuteCancel);
            SavePwdCommand = new RelayCommand(ExecuteSavePwd);
            // _dialogService = dialogService;
           
            this.db = db;
          
         
            // 通过Prism的容器实例获取IContainerExtension
        }
      

        #region 命令
        public ICommand InitializingCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SavePwdCommand { get; set; }
      

        #endregion
        #region 方法
        // IServiceProvider serviceProvider;

        /// <summary>
        /// 界面初始化
        /// </summary>
        private void ExecuteLoading()
        {
            //  TaskQueued.Enqueue((provider) => { });

           
            UserName = $@"{_configuration["Login:UserName"]}";
            PassWord = _configuration["Login:Pwd"];
            App.Configuration.Reload();

            var service=App.GetService<IUserProvider>();

        }
      
        public int Get(int id)
        {
            if (id < 3) 
            {
               // throw Oops.Oh(ErrorCodes.z1000,id,3);
            }
            return id;
        }
        private void ExecuteLogin()
        {
           // Native.CreateInstance<MainView>().ShowDialog();
            _dialogService.Show("AddDialog");
        }

        /// <summary>
        /// 记住密码
        /// </summary>
        private void ExecuteSavePwd()
        {
            LoginAccountDto loginDto = new LoginAccountDto();
            loginDto.UserName = UserName;
            loginDto.Password = PassWord;
            loginDto.IsSelected = LoginArgs.IsSelected;
            _loginService.SavePassWord(loginDto);
                     
        }

        private void ExecuteCancel()
        {
           Application.Current.Shutdown();
        }
        #endregion

        private static bool CanSignIn(string username, string password) => !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
    }
}
