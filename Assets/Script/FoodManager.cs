using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour {
    Color OrigCol;
    public static string ObjectName;
    // Use this for initialization

    void Start () {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetTheFood()
    {
        OrigCol = gameObject.GetComponent<Renderer>().material.color;
        ObjectName = this.gameObject.name;
    }

    public static string PassObjcetName()
    {
        return ObjectName;
    }


    public void LeaveTheFood()
    {
        gameObject.GetComponent<Renderer>().material.color = OrigCol;
        ObjectName = null;
    }
}
