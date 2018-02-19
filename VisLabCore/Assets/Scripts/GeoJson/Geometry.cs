// Geometry.cs
using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

public enum GeometryType {
    Point,
    MultiPoint, 
    LineString,
    MultiLineString, 
    Polygon, 
    MultiPolygon,
    GeometryCollection
}

public class Geometry 
{
    GeometryType geometryType;
    JArray coordinateArrayRaw;
    Array coordinateArray;
    
    public Geometry(GeometryType geometryType, JArray coordinateArrayRaw) 
    {
        this.geometryType = geometryType;
        this.coordinateArrayRaw = coordinateArrayRaw;
        coordinateArray = ParseCoordinateArray(this.coordinateArray);
    }

    public Array ParseCoordinateArray(JToken root)
    {
        Queue<Tuple<List<int>, JToken>> searchQueue = new Queue<Tuple<List<int>, JToken>>();
        searchQueue.Enqueue(new Tuple<List<int>, JToken>(new List<int>(), root));
        int dimensionality = 0;
        List<int> dims_ = new List<int>();
        Array arr = null;

        while (searchQueue.Count > 0)
        {
            Tuple<List<int>, JToken> jt = searchQueue.Dequeue();
            if (jt.Item1.Count > dimensionality) dimensionality = jt.Item1.Count;
            switch (jt.Item2.Type)
            {
                case JTokenType.Array:
                    int length = 0;
                    foreach (JToken tok in jt.Item2)
                    {
                        List<int> l = new List<int>();
                        l.AddRange(jt.Item1);
                        l.Add(length);
                        searchQueue.Enqueue(new Tuple<List<int>, JToken>(l, tok));
                        length++;
                    }
                    if (dims_.Count <= dimensionality)
                        dims_.Add(length);
                    break;
                case JTokenType.Float:
                    if (arr == null)
                    {
                        // If the final array object has not been created, then create it
                        // Once the actual data has been reached, the dimensionality should be established
                        List<int> lowerBounds = new List<int>();
                        foreach (int i in dims_) lowerBounds.Add(0);
                        arr = Array.CreateInstance(typeof(float), dims_.ToArray(), lowerBounds.ToArray());
                    }
                    arr.SetValue(jt.Item2.ToObject<float>(), jt.Item1.ToArray());
                    break;
            }
        }

        return arr;
    }
}