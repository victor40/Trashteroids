using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCounter : MonoBehaviour {
    public float barDisplay = 0;
    public Vector2 pos = new Vector2(4,4);
    public Vector2 size = new Vector2(200,30);
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;
    public Texture2D picture;
    // Use this for initialization
    GameObject earth;
	void Start () {
        earth = GameObject.Find("Earth");
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(pos.x+size.x, pos.y, 24, 24), picture);
        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
        GUI.color = Color.red;
        GUI.backgroundColor = Color.red;
        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.color = Color.red;
        GUI.backgroundColor = Color.red;
        GUI.EndGroup();


        GUI.EndGroup();
        // Update is called once per frame
    }
	void Update () {
        EarthLife lifeScript = earth.GetComponent<EarthLife>();
        barDisplay = lifeScript.getMyLife();
    }
}
