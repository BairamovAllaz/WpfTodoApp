using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoWpf.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<string> TodoCollection { get; set; }
        private string _selecteditem;

        public string SelectedItem
        {
            get => _selecteditem;
            set
            {
                if(value == _selecteditem) return;
                _selecteditem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public MainWindow()
        {
            TodoCollection = new ObservableCollection<string>();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TodoBox.Text)) return;
            TodoCollection.Add(TodoBox.Text);
            TodoBox.Text = "";
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            TodoCollection.RemoveAt(TodoCollection.Count - 1);
        }
        
        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectedItem)) MessageBox.Show("Select an item to update");
            int index = TodoCollection.IndexOf(SelectedItem);
            TodoCollection[index] = TodoBox.Text;
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}