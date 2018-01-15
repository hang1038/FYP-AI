using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    public float SelectingTime = 0f;
    private ChangeColor ColorTemp;
    Color OrigCol;
    // Use this for initialization
    void Start () {

        ColorTemp = GetComponent<ChangeColor>();
        OrigCol = gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnDisable()
    {
        SelectingTime = 0f;
    }

    // Update is called once per frame
    void Update () {

        SelectingTime += Time.deltaTime;

        if (SelectingTime < 3f)
        {
            ChangeFoodcolor(SelectingTime/3);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = OrigCol;
            ColorTemp.enabled = false;
        }
    }
    public void ChangeFoodcolor(float t)
    {  
            gameObject.GetComponent<Renderer>().material.color = new Color(OrigCol.r-t, OrigCol.g-t, OrigCol.b-t, OrigCol.a);
    }
}
