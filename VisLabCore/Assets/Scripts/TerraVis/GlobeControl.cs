using UnityEngine;

public class GlobeControl : MonoBehaviour
{
    private Vector3 ROTATION_VECTOR = new Vector3(0, 0.1f, 0);

    private Transform transform;

    void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate(ROTATION_VECTOR); 
    }
}