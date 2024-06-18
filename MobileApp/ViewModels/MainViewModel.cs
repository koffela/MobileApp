using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.ComponentModel;
using System.Windows.Input;

namespace MobileApp.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged //needed this to update UI
    {
        private string _myTextProperty;
        public string MyTextProperty
        {
            get => _myTextProperty;
            set
            {
                _myTextProperty = value;
                OnPropertyChanged(nameof(MyTextProperty)); // Notify UI that property has changed NEEDED as above
            }
        }

        public string Greeting => "Custom App V1.0.1";

        public MainViewModel()
        {
            // Create a command that will be executed when the button is clicked
            ButtonClickCommand = ReactiveCommand.Create(ButtonClick);
        }

        public ICommand ButtonClickCommand { get; }

        private void ButtonClick()
        {
            // Code to be executed when the button is clicked
            // For example, set the text of the text box
            MyTextProperty = "Button clicked!";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) //the actual implementation of 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
