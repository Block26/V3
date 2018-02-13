// GeoJsonParser.cs
using Newtonsoft.Json.Linq;

public class GeoJsonParser {
    public GeoJsonParser() {
        
    }
    
    public void Parse(text) {
        JObject geoJson = JObject.Parse(text);
        string type = (string)geoJson.SelectToken("type");
        if (type == "FeatureCollection") {
            
        }
    }
}