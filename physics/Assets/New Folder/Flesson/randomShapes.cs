using UnityEngine;
using System.Collections;

public class randomShapes : MonoBehaviour {
    public int num = 100;
    public float delta_time = 0;

    public int height = 25;
    public int radius = 25;
    public bool stack = false;

    public GameObject istance01;
    float last_time = 0;
    int last_done = 0;
	// Use this for initialization
	void Start () {
	    if(delta_time == 0)
        {
            for(int i=0;i<num; ++i)
            {
                createShape();
            }
        }
        else
        {
            last_time = Time.time;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time - last_time > delta_time)
        {
            createShape();
            last_time = Time.time;
        }
	}

    void createShape()
    {
        var shape = Instantiate(istance01);
        if (!stack)
        {
            var pos = Random.insideUnitCircle * radius;
            shape.transform.position = Vector3.forward * pos.x * radius + Vector3.left * pos.y * radius + Vector3.up * height;
        }
        else
        {
            shape.transform.position = Vector3.up * height;
        }
    }
}
