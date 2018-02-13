// Geometry.cs

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
}