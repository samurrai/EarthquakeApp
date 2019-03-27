using Newtonsoft.Json;
using System.Collections.Generic;

namespace EarthquakesApp.Models
{
    public class FeatureCollection
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("features")]
        public IList<Feature> Features { get; set; }
    }

}
