using Lands.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lands.Services
{
    public class ApiService
    {
        public async Task<Reponse> ChecConecction()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Reponse
                {
                    IsSuccess = false,
                    Menssage = "Por Favor conectarse a wifi",
                };
            }
            var isReacable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReacable)
            {
                return new Reponse
                {
                    IsSuccess = false,
                    Menssage = "Chekiar la conexxion a internet",

                };
               
            }
            return new Reponse
            {
                IsSuccess = true,
                Menssage = "ok",
            };
        }
        public async Task<TokenReponse> GetToken(
            string urlBase,
            string username,
            string pasword)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var reponse = await client.PostAsync(
                    "Token",
                    new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                    username, pasword),
                    Encoding.UTF8, "aplication/x-www-form-urlencoded"
                    ));
                var resulJSON = await reponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenReponse>(resulJSON);
                return result;
                
            }
            catch
            {
                return null;
            }

        }
        public async Task<Reponse> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Reponse
                    {
                        IsSuccess = false,
                        Menssage = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Reponse
                {
                    IsSuccess = true,
                    Menssage = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Reponse
                {
                    IsSuccess = false,
                    Menssage = ex.Message,
                };
            }
        }

    }
}
