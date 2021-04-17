using ReactiveUI;
using ServerCreation.Engine;
using ServerCreation.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ServerCreation.ViewModels
{
    public class ViewModelBase : ReactiveObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string Name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
    }
}
