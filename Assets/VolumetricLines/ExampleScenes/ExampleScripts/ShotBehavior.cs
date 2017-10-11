using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "astroid" || other.gameObject.name == "Earth")
        {
            Destroy(gameObject);
        }
    }
}


