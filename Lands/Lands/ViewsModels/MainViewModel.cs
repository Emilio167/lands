using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewsModels
{
    public class MainViewModel
    {
        #region viewModel
        public LoginViewModel Login  { get; set; }
        public LandsViewModel Lands { get; set; }
        #endregion
        #region Construtor
        public MainViewModel() {
            intance = this;
            this.Login = new LoginViewModel();        

        }
        #endregion
        #region Singleton 
        public static MainViewModel intance;
        public static MainViewModel Getintance() {
            if (intance ==null)
            {
                return new MainViewModel();
            }
            return intance;
        }
        #endregion
    }
}
