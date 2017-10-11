using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCounter : MonoBehaviour
{
    public float barDisplay = 0;
    public Vector2 pos = new Vector2(4, 40);
    public Vector2 size = new Vector2(200, 30);
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;
    public Texture2D picture;
    // Use this for initialization
    GameObject player;
    GameObject earth;
    
    void Start()
    {
        player = GameObject.Find("Player");
        earth = GameObject.Find("Earth");
        StartCoroutine("MyEvent");
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(pos.x + size.x, pos.y, 24, 24), picture);
        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
        GUI.color = Color.blue;
        GUI.backgroundColor = Color.blue;
        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.color = Color.blue;
        GUI.backgroundColor = Color.blue;
        GUI.EndGroup();

        GUI.EndGroup();
        // Update is called once per frame
    }
    void Update()
    {
       Energy energyScript = player.GetComponent<Energy>();
       barDisplay = energyScript.getMyEnergy();
/*       if(Vector3.Distance(player.transform.position, earth.transform.position) < 20)
        {
            energyScript.dealHeal();

        }*/
    }

    private IEnumerator MyEvent()
    {
        while (true)
        {
            Energy energyScript = player.GetComponent<Energy>();
            yield return new WaitForSeconds(0.2f);
            if (Vector3.Distance(player.transform.position, earth.transform.position) < 13)
            {
                energyScript.dealHeal();
            }
        }
    }
}
