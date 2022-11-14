using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Birds.Models
{
    [ObservableObject]
    public partial class BirdRepository
    {
        public ObservableCollection<Bird> Birds { get; set; }

        public BirdRepository()
        {
            Birds = new ObservableCollection<Bird>();

            foreach (var bird in LoadBirds())
            {
                Birds.Add(bird);
            }
        }

        public IEnumerable<Bird> LoadBirds()
        {
            var path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Assets\\BirdsData\\Birds");
            using (var stream = File.OpenRead(path))
            {
                using (JsonDocument document = JsonDocument.Parse(stream))
                {
                    JsonElement rootElement = document.RootElement;
                    foreach (var birdElement in rootElement.EnumerateArray())
                    {
                        var bird = ReadBird(birdElement);
                        yield return bird;
                    }
                }
            }
        }

        private Bird ReadBird(JsonElement birdElement)
        {
            var bird = new Bird();
            JsonElement jsonElement;

            if (birdElement.TryGetProperty("family", out jsonElement))
            {
                bird.Family = jsonElement.GetString() ?? "";
            }
            if (birdElement.TryGetProperty("genus", out jsonElement))
            {
                bird.Genus = jsonElement.GetString() ?? "";
            }
            if (birdElement.TryGetProperty("specie", out jsonElement))
            {
                bird.Specie = jsonElement.GetString() ?? "";
            }
            if (birdElement.TryGetProperty("commonName", out jsonElement))
            {
                bird.CommonName = jsonElement.GetString() ?? "";
            }
            if (birdElement.TryGetProperty("latinName", out jsonElement))
            {
                bird.LatinName = jsonElement.GetString() ?? "";
            }
            if (birdElement.TryGetProperty("description", out jsonElement))
            {
                bird.Description = jsonElement.GetString() ?? "";
            }
            if (birdElement.TryGetProperty("imagePath", out jsonElement))
            {
                bird.ImageName = jsonElement.GetString() ?? "";

            }
            return bird;
        }
    }
}
