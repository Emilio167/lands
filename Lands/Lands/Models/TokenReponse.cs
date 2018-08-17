using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    public class TokenReponse
    {
        #region propiedades
        [JsonProperty(PropertyName = "acces_token")]
        public string AcessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public string ExpiresIn { get; set; }
        [JsonProperty(PropertyName = "UserName")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "Issued")]
        public string Issued { get; set; }
        [JsonProperty(PropertyName = "expires")]
        public string Expires { get; set; }
        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
        public bool IsRembered
        {
            get;
            set;
        }
        public bool Password
        {
            get;
            set;
        }
        #endregion
    }
}
