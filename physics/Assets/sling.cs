using UnityEngine;
using System.Collections;

public class sling : MonoBehaviour {
    public bool shoot = true;
    public GameObject bullet;
	// Update is called once per frame
	void Update () {
        if (!Input.GetButton("Fire1"))
            return;

        if (shoot)
        {
            var b = Instantiate(bullet);
            b.transform.position = transform.position;
            b.transform.rotation = transform.rotation;
            b.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            b.GetComponent<Rigidbody>().angularVelocity = GetComponent<Rigidbody>().angularVelocity;
        }
        else
        {
            Destroy(GetComponent<FixedJoint>());
        }
        
	}
}
