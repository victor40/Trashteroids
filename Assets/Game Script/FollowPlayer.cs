using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform playerTransform;

	void Start () {
		
	}

	void Update () {
		transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, -11);
	}
}
