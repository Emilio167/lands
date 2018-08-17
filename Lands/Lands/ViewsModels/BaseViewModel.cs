using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lands.ViewsModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertiName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertiName));
        }
        protected void SetValue <T>(ref T backingField, T value ,[CallerMemberName] string propertiName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) {
                return;
            }
            backingField = value;
            OnPropertyChanged(propertiName);
        }
    }
}
