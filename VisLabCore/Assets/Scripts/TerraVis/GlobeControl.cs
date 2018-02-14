using UnityEngine;

public class GlobeControl : MonoBehaviour
{

    private Vector3 ROTATION_VECTOR =  new Vector3(0,0.5f,0);

    void Start()
    {

    }

    void Update()
    {
        this.GetComponent<Transform>().Rotate(ROTATION_VECTOR);  
    }
}