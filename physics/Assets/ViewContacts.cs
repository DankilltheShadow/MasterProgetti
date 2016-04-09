using UnityEngine;
using System.Collections;

public class ViewContacts : MonoBehaviour {
    public GameObject small;

	public void OnCollisionEnter(Collision collision)
    {
        visualizeContacts(collision.contacts);
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        visualizeContacts(collision.contacts);
    }

    public void visualizeContacts(ContactPoint[] contacts)
    {
        foreach (var contact in contacts)
        {
            var sphere = GameObject.Instantiate(small);
            sphere.transform.position = contact.point;
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
