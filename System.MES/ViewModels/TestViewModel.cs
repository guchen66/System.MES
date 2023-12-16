
using Microsoft.Extensions.Configuration;

namespace System.MES.ViewModels
{
    public class TestViewModel:BindableBase
    {
		private string _content;

		public string Content
		{
			get { return _content; }
			set { SetProperty<string>(ref _content, value); }
		}
        public TestViewModel()
        {
            ShowCommand = new RelayCommand(ExecuteText);
        }
        public ICommand ShowCommand { get; set; }

        public void ExecuteText()
        {
            Content = App.Configuration["Login:Name"];
            App.Configuration.Reload();
        }
	}
}
