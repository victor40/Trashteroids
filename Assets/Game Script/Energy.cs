using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int PercentLife = 1;
    int myEnergy;
    float myDecEnergy;
    // Use this for initialization
    void Start()
    {
        myEnergy = 100;
        StartCoroutine("MyEvent");
    }

    // Update is called once per frame
    void Update()
    {
        if (myEnergy <= 0)
        {

            myDecEnergy = 0;
            Application.LoadLevel(7);

        }
        else if (myEnergy > 100)
        {

            myEnergy = 100;
        }

        myDecEnergy = (float)myEnergy / 100;

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        print("delay executed");
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

    public float getMyEnergy()
    {
        return (myDecEnergy);
    }

    public void dealDamage()
    {
        myEnergy = myEnergy - 23;
    }

    public void dealHeal()
    {
        myEnergy = myEnergy + 3;
    }


    private IEnumerator MyEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.9f); // wait .9 second
                                                   // do things
            myEnergy = myEnergy - 2;
        }
    }
}
