// GeoJsonParser.cs
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class GeoJsonParser {
    public GeoJsonParser() {
        
    }
    
    public void Parse(string text) {
        JObject geoJson = JObject.Parse(text);
        string type = (string)geoJson.SelectToken("type");
        if (type == "FeatureCollection") {
            List<Feature> features = new List<Feature>();
            JArray arr = (JArray)geoJson.SelectToken("features");
            foreach (JToken feature in arr) {
                JToken geometry = feature.SelectToken("geometry");
                Geometry geo = new Geometry((GeometryType)Enum.Parse(typeof(GeometryType), (string)geometry.SelectToken("type")), (JArray)geometry.SelectToken("coordinates"));
                Feature feat = new Feature((string)feature.SelectToken("type"), (JObject)feature.SelectToken("properties"), geo);
                features.Add(feat);
            }
        }
    }
}