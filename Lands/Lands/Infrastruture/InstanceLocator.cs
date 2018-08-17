using System;
using System.Collections.Generic;
using System.Text;
using Lands.ViewsModels;

namespace Lands.Infrastruture
{  
    public class InstanceLocator
    {
        #region Propiedades
        public  MainViewModel Main { get; set; }
        #endregion
        #region construtor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();  
        }
        #endregion
    }
}
