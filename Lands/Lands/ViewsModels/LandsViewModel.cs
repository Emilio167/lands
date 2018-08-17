using Lands.Models;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    public class LandsViewModel:BaseViewModel
    {
        #region servicios
        private ApiService apiService;
        #endregion
        #region atributos
        private ObservableCollection<Land> land;
        #endregion
        #region propiedades
        public ObservableCollection<Land> Land
        {
            get { return this.land; }
            set { SetValue(ref this.land, value); }
        }
        #endregion
        #region contructor
        public LandsViewModel()
        {
            apiService = new ApiService();
            this.LoadLands();
        }
        #endregion
        #region metodos publico 
        private async void LoadLands()
        {
            var conexion = await apiService.ChecConecction();
            if (!conexion.IsSuccess) {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                conexion.Menssage,
                "Aceptar"
                );
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var reponse = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");
            if (!reponse.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   reponse.Menssage,
                   "Aceptar"
                   );
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var list =(List<Land>)reponse.Result;
            this.Land = new ObservableCollection<Land>(list);


        }
        #endregion
    }
}

