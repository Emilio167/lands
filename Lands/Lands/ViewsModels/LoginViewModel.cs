using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public  class LoginViewModel:BaseViewModel
    {
       
        #region Atributos
        private string email;
        private string password;
        private bool isRunning;
        private bool isRemeber;
        private bool isEnabled = true;
        #endregion
        #region propiedades        
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning {
            get { return this.isRunning; }
           set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemeber
        {
            get { return this.isRemeber; }
            set{ SetValue(ref this.isRemeber, value); }
        }
        public bool IsEnabled {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion
        #region Contrutor
        public LoginViewModel() {
           this.IsRemeber = false;
            this.IsEnabled = true;
        }    
        #endregion
        #region comando
        public ICommand LoginCommand {
            get
            {            
                return new RelayCommand(Login);
            }
        }
        private async void Login()
        {
            this.IsRemeber = true;
            if (string.IsNullOrEmpty(this.Email)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresar el Email",
                    "Aceptar" 
                    );
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresar el pasword",
                    "Aceptar"
                    );
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            if (this.Email !="a@a.com" || this.Password!="12345" ) {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Error al ingresar el usuario",
                   "Aceptar"
                   );
                this.Password = string.Empty;
                this.IsRunning = false;
                this.IsEnabled = true;
                return;
            }
            this.Email = string.Empty;
            this.Password = string.Empty;
            MainViewModel.Getintance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
       
        }
        public ICommand RegiterCommand { get;  }      

        #endregion
    }
}
