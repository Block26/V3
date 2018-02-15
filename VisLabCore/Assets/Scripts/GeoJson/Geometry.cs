// Geometry.cs
using Newtonsoft.Json.Linq;

public enum GeometryType {
    Point,
    MultiPoint, 
    LineString,
    MultiLineString, 
    Polygon, 
    MultiPolygon,
    GeometryCollection
}

public class Geometry {
    GeometryType geometryType;
    JArray coordinateArray;
    
    public Geometry(GeometryType geometryType, JArray coordinateArray) {
        this.geometryType = geometryType;
        this.coordinateArray = coordinateArray;
    }
}