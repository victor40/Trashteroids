using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSegScript : MonoBehaviour {
    public Vector3 CenterPos = new Vector3(0, 0, 0);
    bool goAhead = false;
	// Use this for initialization
	void Start () {
		
	}

    public void SetCenter(Vector3 center)
    {
        CenterPos = new Vector3(center.x,center.y,center.z);
        goAhead = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (goAhead)
        {
            transform.RotateAround(CenterPos, Vector3.forward, 10 * Time.deltaTime);
        }
	}

    void OnTriggerEnter(Collider collision)
    {
        
        print(collision.gameObject.name);
        if (collision.gameObject.name == "astroid")
        {

            Destroy(gameObject);
            
        }
    }

}
