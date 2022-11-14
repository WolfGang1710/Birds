using Birds.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml;
using CommunityToolkit.WinUI.UI;

namespace Birds.ViewModels
{
    [ObservableObject]
    public partial class BirdsViewModel
    {
        [ObservableProperty]
        private BirdRepository birdRepository;
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(HasCurrent))]
        //[AlsoNotifyCanExecuteFor(nameof(DeleteCommand))]
        private Bird? current;
        private string filter = "";
        public BirdsViewModel(BirdRepository birdRepository)
        {
            this.birdRepository = birdRepository;
            DeleteCommand = new RelayCommand<Bird>(Delete,
                bird => bird is not null);
            Current = birdRepository.Birds.FirstOrDefault();
            FilteredBirds = new AdvancedCollectionView(birdRepository.Birds, true);
            FilteredBirds.Filter = x => (x is Bird bird && Filter.Trim().Length != 0) ?
            bird.CommonName.Contains(Filter.Trim(), StringComparison.CurrentCultureIgnoreCase) : true;
            FilteredBirds.ObserveFilterProperty(nameof(Bird.CommonName));
        }

        public bool HasCurrent => Current is not null;
        public IRelayCommand<Bird> DeleteCommand { get; }

        private void Delete(Bird? bird)
        {
            if (bird is not null)
            {
                _ = birdRepository.Birds.Remove(bird);
            }
        }

        public AdvancedCollectionView FilteredBirds { get; private set; }

        public string Filter
        {
            get => filter;
            set
            {
                SetProperty(ref filter, value);
                FilteredBirds.RefreshFilter();
            }
        }
    }
}
