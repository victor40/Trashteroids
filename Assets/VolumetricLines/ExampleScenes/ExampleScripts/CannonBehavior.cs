using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public GameObject m_shotPrefab;
	public Transform player;

	public float fireDelay;
	public float shotSpeed;
	private float elapsedTime = 0;

	void Update () {
		elapsedTime += Time.deltaTime;

		if (Input.GetAxisRaw("Fire1") > 0) {
			if (elapsedTime > fireDelay) { 
				GameObject go = GameObject.Instantiate(m_shotPrefab) as GameObject;
				go.transform.position = player.position;
                CapsuleCollider bulletCol = go.AddComponent<CapsuleCollider>();
                Physics.IgnoreCollision(bulletCol, player.GetComponent<Collider>());
                Physics.IgnoreCollision(bulletCol, GetComponent<Collider>());
                bulletCol.isTrigger = true;
                go.AddComponent<ShotBehavior>();

				Vector3 mousePosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
					Input.mousePosition.z));
				Vector3 direction = new Vector3(mousePosition.x - player.position.x, mousePosition.y - player.position.y, 0);
				direction.Normalize ();

				go.GetComponent<Rigidbody> ().velocity = direction * shotSpeed;
				GameObject.Destroy(go, 3f);

				elapsedTime = 0;
			}
		}
	}
}
