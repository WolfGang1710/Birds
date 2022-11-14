using Birds.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Birds.Views
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    [ObservableObject]
    public sealed partial class EditDialog : ContentDialog
    {
        private Bird? bird;
        public EditDialog()
        {
            edited = new Bird();
            this.InitializeComponent();
            UpdateCommand = new RelayCommand(Update);
            PrimaryButtonCommand = UpdateCommand;
        }
        public Bird? Bird
        {
            get => bird;
            set
            {
                bird = value;
                if (bird != null)
                    edited.CopyFrom(bird);
            }
        }
        [ObservableProperty]
        private Bird edited;
        public ICommand UpdateCommand { get; set; }
        private void Update()
        {
            Bird?.CopyFrom(edited);
        }
    }
}
