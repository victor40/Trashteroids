using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashteroid : MonoBehaviour {

    public float speed = 5.0f;
    public int splitCount = 0;
    Vector3 travel;
    Vector3 earthPos;
    public bool isColliding = false;
    public bool canBeHit = false;


    // Use this for initialization
    void Start () {
        earthPos = GameObject.Find("Earth").transform.position;
        travel = (earthPos - transform.position).normalized * speed;
        StartCoroutine("DelayEvent");
        canBeHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        isColliding = false;
        travel = (earthPos - transform.position).normalized * speed;
        GetComponent<Rigidbody>().velocity = travel;
        transform.Rotate(Vector3.forward, speed*Time.deltaTime, Space.World);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player") && (canBeHit == true))
        {
            Energy energy = collision.gameObject.GetComponent<Energy>();
            energy.dealDamage();
            Destroy(gameObject);
        }
    }

    private IEnumerator DelayEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            canBeHit = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == "Earth")
        {
            EarthLife lifeScript = collision.gameObject.GetComponent<EarthLife>();
            lifeScript.dealDamage();
            Destroy(gameObject);
        }
        else if (collision.gameObject.name.Equals("shield"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.name.Equals("Player"))
        {
/*Energy energy = collision.gameObject.GetComponent<Energy>();
energy.dealDamage();
Split();*/
        }
        else
        {
            Split();
        }
    }

    private void Split()
    {
        if (isColliding)
        {
            return;
        }
        isColliding = true;
        if (splitCount <= 1)
        {
            Quaternion rotate1 = Quaternion.EulerAngles(0, 0, 20);
            Quaternion rotate2 = Quaternion.EulerAngles(0, 0, -20);
            GameObject child1 = Instantiate(gameObject, transform.position + rotate1*travel.normalized*3, transform.rotation);
            GameObject child2 = Instantiate(gameObject, transform.position + rotate2*travel.normalized*3, transform.rotation);
            child1.name = "astroid";
            child2.name = "astroid";
            child1.transform.position = new Vector3(child1.transform.position.x, child1.transform.position.y, 0);
            child2.transform.position = new Vector3(child2.transform.position.x, child2.transform.position.y, 0);

            child1.transform.localScale = transform.localScale - new Vector3(0.15f, 0.15f, 0.15f);
            child2.transform.localScale = transform.localScale - new Vector3(0.15f, 0.15f, 0.15f);

            child1.GetComponent<Trashteroid>().splitCount = splitCount + 1;
            child2.GetComponent<Trashteroid>().splitCount = splitCount + 1;
        }

        Destroy(gameObject);
    }
}
