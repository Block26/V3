using UnityEngine;

public class GlobeControl : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public GameObject obj;

    private Vector3 ROTATION_VECTOR =  new Vector3(0,0.5f,0);

    void Start()
    {

    }

    void Update()
    {
        this.GetComponent<Transform>().Rotate(ROTATION_VECTOR);  
    }

    //Implement translation of scene coordinates to Earth coordinates

}