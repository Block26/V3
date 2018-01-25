using UnityEngine;

public class GlobeControl : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public GameObject obj;

    private Vector3 position;

    void Start()
    {
        position = new Vector3(x, y, z);
    }

    void Update()
    {
        position = new Vector3(x, y, z);   
    }
}