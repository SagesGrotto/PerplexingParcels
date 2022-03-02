using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            Goal.goalMet = true;
 //           Debug.Log(goalMet);
            Material mat = GetComponent<Renderer>().material;
            mat.color = new Color(0.196f,1.0f, 0.196f);
        }
    }
}
