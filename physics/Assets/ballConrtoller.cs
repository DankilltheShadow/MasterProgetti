using UnityEngine;
using System.Collections;

public class ballConrtoller : MonoBehaviour {
    public float force_scale = 1;
    public float torque_scale = 1;
	
	// Update is called once per frame
	void FixedUpdate () {
        var rb = GetComponent<Rigidbody>();

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var force = new Vector3(x, 0, y) * force_scale;

        rb.AddForce(force);

        var torque = new Vector3(y, 0, -x) * torque_scale;
        rb.AddTorque(torque);
    }
}
