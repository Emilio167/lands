using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    public class Reponse
    {
        public bool IsSuccess { get; set; }
        public String Menssage { get; set; }
        public object Result { get; set; }
    }
}
