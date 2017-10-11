using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthLife : MonoBehaviour {
    public int PercentLife = 4;
    int myLife;
    float myDecLife;
	// Use this for initialization
	void Start () {
        myLife = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if(myLife <= 0)
        {
            //GameObject player = GameObject.Find("Player");
            //TimerScript sc = player.GetComponent<TimerScript>();
            //sc.StopTimer();
            myDecLife = 0;
            Application.LoadLevel(7);
            //ExecuteAfterTime(2.0f);
            

        }
        myDecLife = (float)myLife / 100;

	}

    public void Die()
    {
        print("i'm dead");
            GameObject player = GameObject.Find("Player");
            TimerScript sc = player.GetComponent<TimerScript>();
            sc.StopTimer();
            myDecLife = 0;
            ExecuteAfterTime(2.0f);


    }

    public IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Application.LoadLevel(7);
                // Code to execute after the delay
            }
   /* void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name == "astroid")
        {
            myLife = myLife - PercentLife;
        }
 
    }*/

    public float getMyLife()
    {
        return (myDecLife);
    }

    public void dealDamage()
    {
        myLife = myLife - PercentLife;
        if(myLife <= 0)
        {
            SceneManager.LoadScene("Game Over Scene");
        }

    }
}
