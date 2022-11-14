using Birds.Models;
using Birds.ViewModels;
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
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Birds.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BirdsView : Page
    {
        public BirdsView()
        {
            this.InitializeComponent();
            ViewModel = new BirdsViewModel(new BirdRepository());
            EditCommand = new AsyncRelayCommand(OpenEditDialog);
        }

        public BirdsViewModel ViewModel { get; set; }
        public ICommand EditCommand { get; set; }

        private async Task OpenEditDialog()
        {
            var editDialog = new EditDialog();
            editDialog.XamlRoot = this.XamlRoot;
            editDialog.Bird = ViewModel.Current;
            await editDialog.ShowAsync();
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender,
AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.Filter = args.QueryText;
        }

    }
}
