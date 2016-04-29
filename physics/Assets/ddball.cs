using UnityEngine;
using System.Collections;

public class ddball : MonoBehaviour {
    public float torque;
    public float jump;
    public bool jumpTouch = true;
	// Update is called once per frame
	void FixedUpdate () {
        var t = Input.GetAxis("Horizontal");
        var rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(0, 0, -torque * t ));

        if (Input.GetButton("Jump"))
        {
            if (jumpTouch)
            {
                Ray ray = new Ray(transform.position + 0.5f * Vector3.down, Vector3.down);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit, 0.1f))
                {

                

                if (hit.collider.tag == "ray") rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
                }
            }
        }
	}
}
