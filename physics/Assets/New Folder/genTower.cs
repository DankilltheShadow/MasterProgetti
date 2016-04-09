using UnityEngine;
using System.Collections;

public class genTower : MonoBehaviour {
    public int numx = 4, numy = 10, numz = 1;
    public GameObject istance01;
    // Use this for initialization
    void Start () {
	    for(int i= 0; i< numx; ++i)
        {
            for (int j = 0; j < numy; ++j)
            {
                for (int k = 0; k < numz; ++k)
                {
                    var shape = Instantiate(istance01);
                    
                    shape.transform.position = ;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
