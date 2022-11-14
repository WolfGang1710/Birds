using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birds.Models
{
    [ObservableObject]
    public partial class Bird
    {
        [ObservableProperty]
        private string family;

        [ObservableProperty]
        private string genus;

        [ObservableProperty]
        private string specie;

        [ObservableProperty]
        private string commonName;

        [ObservableProperty]
        private string latinName;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(Image))]
        private string imageName;

        public Bird()
        {
            family = "";
            genus = "";
            specie = "";
            commonName = "";
            latinName = "";
            description = "";
            imageName = "";
        }

        public BitmapImage Image
        {
            get
            {
                var uri = new System.Uri($"ms-appx:///Assets/BirdsData/{imageName}");
                return uri is not null ? new BitmapImage(uri) : new BitmapImage();
            }
        }

        
        public virtual void CopyFrom(Bird other)
        {
            Family = other.Family;
            Genus = other.Genus;
            Specie = other.Specie;
            CommonName = other.CommonName;
            LatinName = other.LatinName;
            Description = other.Description;
            ImageName = other.ImageName;
        }
    }
}
