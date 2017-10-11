using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public Camera camera;
	public Boundary boundary;
	
	void FixedUpdate () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed, 0);
		
		Vector3 mousePosition = camera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
			Input.mousePosition.z - camera.transform.position.z));
		rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y),
			(mousePosition.x - transform.position.x))* Mathf.Rad2Deg - 90);
	
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax));
	}
}
