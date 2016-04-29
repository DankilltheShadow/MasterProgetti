using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour {

    public float speed = 1;

    // Update is called once per frame
    void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0.0f, moveV);

        Rigidbody rb = GetComponent<Rigidbody>();
        var t = transform.TransformPoint(new Vector3(0, -1, 0));
        rb.AddForce(move * speed);
        //rb.AddForceAtPosition(move * speed, t);
    }
}
