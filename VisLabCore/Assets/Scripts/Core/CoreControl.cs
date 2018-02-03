using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreControl : MonoBehaviour {

    private Transform transform;

    private Vector3 ROTATION = new Vector3(0.5f, 0.5f, 0.5f);

	// Use this for initialization
	void Start () {
        transform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(ROTATION);
	}
}
