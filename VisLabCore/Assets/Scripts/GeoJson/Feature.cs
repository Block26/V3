// Feature.cs
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class Feature {
    string type;
    IDictionary<string, string> properties;
    Geometry geometry;
    
    public Feature(string type, IDictionary<string, string> properties, Geometry geometry) {
        this.type = type;
        this.properties = properties;
        this.geometry = geometry;
    }
}