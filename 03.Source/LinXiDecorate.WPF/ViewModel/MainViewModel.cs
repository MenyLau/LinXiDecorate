using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace LinXiDecorate.WPF.ViewModel
{
    public class MainViewModel
    {
        ObservableCollection<UIElement> rooms = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Rooms
        {
            get
            {
                return rooms;
            }

            set
            {
                rooms = value;
            }
        }
    }
}
