using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour {
    public float startTime;
	public int TimeScore;
    Text timeText;
    public bool IsTimeEnd;
    // Use this for initialization
    void Awake()
    {
        timeText = GetComponent<Text>();
        IsTimeEnd = false;
    }
    // Update is called once per frame
    void Update () {
        if (!IsTimeEnd)
        {
            startTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(startTime / 60F);
			int seconds = Mathf.FloorToInt(startTime - minutes * 60);
			TimeScore = Mathf.FloorToInt(startTime + minutes * 60);
			timeText.text = "Time: " + minutes + " : " + seconds;
			if (seconds == 0&&minutes == 0 )
            {
                    IsTimeEnd = true;
                
            }
        }
        else
        {
            timeText.text = "Ended";
        }
    }
}
