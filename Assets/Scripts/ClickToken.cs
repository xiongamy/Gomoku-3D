using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToken : MonoBehaviour {

    void OnMouseDown()
    {
        if (gameObject.GetComponent<Renderer>().enabled)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
