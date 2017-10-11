using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {
    public GUIStyle style;
    private float startTime;
    private float elapsedTime;
    bool stopTimer;
    // Use this for initialization
    void Start () {
            startTime = 0;
        stopTimer = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!stopTimer)
        {
            elapsedTime = Time.time - startTime;
        }
    }
    public void StopTimer()
    {
        stopTimer = true;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(2, Screen.height - 35, 400, 400), (elapsedTime.ToString()), style);
    }
}
