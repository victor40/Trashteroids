using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class SpawnShieldScript : MonoBehaviour {
    public int numPoints = 8;
    public Vector3 centerPos = new Vector3(0, 0, 0);
    public GameObject spawn = null;
    public int radius = 10;
	// Use this for initialization
	void Start () {
        centerPos = new Vector3(transform.position.x,transform.position.y,transform.position.z + (float)0);
		for(int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            
            float i = (pointNum*(float)1.0) / numPoints;
            float angle = i * Mathf.PI * 2;
            float x = Mathf.Sin(angle)*radius;
            float y = Mathf.Cos(angle)*radius;
            Vector3 pos =  new Vector3(x, y, 0) + centerPos;
            if (spawn != null)
            {
                GameObject returnObj = Instantiate((spawn), pos, Quaternion.identity);
                returnObj.name = "shield";
                float z = Mathf.Tan(angle) * radius;
                float zTan = Mathf.Atan2(y, x);
                float zDeg = (zTan * 180) / Mathf.PI;
                Vector3 rot = new Vector3(180, 180, 0);
                returnObj.transform.Rotate(Vector3.forward, zDeg);
                ShieldSegScript segmentScript = returnObj.GetComponent<ShieldSegScript>();
                segmentScript.SetCenter(centerPos);
                //BoxCollider collider = returnObj.AddComponent<BoxCollider>();
                
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
