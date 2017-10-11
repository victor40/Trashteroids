using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashteroidGen : MonoBehaviour {

    private float timer;
    private float waveTimer = 30f;
    private int astNum;

	// Use this for initialization
	void Start () {
        timer = 10f;
        astNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;
		if(timer <= 0.0f)
        {
            AsteroidSpawn();
            timer = 10f;
        }
        if(waveTimer <= 0.0f)
        {
            astNum++;
            waveTimer = 30f;
        }
	}

    private void AsteroidSpawn()
    {
        for (int i = 0; i < astNum; i++)
        {

            GameObject asteroid;
            float randomAngle = Random.Range(0, Mathf.PI * 2);
            asteroid = Instantiate((GameObject)Resources.Load("astroid"), new Vector3(Mathf.Sin(randomAngle) * 100, Mathf.Cos(randomAngle) * 100, 0), transform.rotation);
            asteroid.name = "astroid";
            asteroid.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Rigidbody astrigid = asteroid.AddComponent<Rigidbody>();
            astrigid.mass = 1;
            astrigid.useGravity = false;
            SphereCollider collider = asteroid.AddComponent<SphereCollider>();
            collider.radius = 6;
			AudioSource audio = asteroid.AddComponent<AudioSource> ();
			audio.clip = Resources.Load ("explosion_asteroid.wav") as AudioClip;
			audio.playOnAwake = false;
            asteroid.AddComponent<Trashteroid>();
            asteroid.GetComponent<Trashteroid>().speed = Random.Range(3, 8);
        }

    }
}
