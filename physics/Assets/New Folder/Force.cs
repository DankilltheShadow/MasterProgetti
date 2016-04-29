using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {
    public float force = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.left*force);
    }
}
