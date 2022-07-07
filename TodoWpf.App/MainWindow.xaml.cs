using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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
            if (string.IsNullOrWhiteSpace(SelectedItem))
            {
                MessageBox.Show("Select an item to update");
                return;
            }
            if (TodoBox.Text == "")
            {
                MessageBox.Show("Write something to update");
                return;
            }
            int index = TodoCollection.IndexOf(SelectedItem);
            TodoCollection[index] = TodoBox.Text;
            TodoBox.Text = "";
        }
        private void ButtonRead_OnClick(object sender, RoutedEventArgs e)
        {
            Selected.Text = SelectedItem;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}