using UnityEngine;
using System.Collections;

public class MoveTurret : MonoBehaviour {

    public float speedT = 1;
    public float bulletSpeed = 1;
    public GameObject bullet;

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Mouse X");
        float moveV = Input.GetAxis("Mouse Y");

        Vector3 torque = new Vector3(moveH, 0.0f, moveV);
        torque = transform.TransformVector(torque);

        var rb = GetComponent<Rigidbody> ();
        rb.AddTorque(transform.TransformVector(torque * speedT));

        if (Input.GetButton("Fire1"))
        {
            var b = Instantiate(bullet);

            var endcannon = transform.TransformPoint(new Vector3(0, 1.5f, 0));
            var dirCannon = transform.TransformDirection(new Vector3(0, 1, 0));
            var impulse = dirCannon * bulletSpeed;

            b.transform.position = endcannon;
            b.GetComponent<Rigidbody>().AddForce(impulse,ForceMode.Impulse);

            rb.AddForceAtPosition(-impulse, endcannon,ForceMode.Impulse);

        }
    }
}
