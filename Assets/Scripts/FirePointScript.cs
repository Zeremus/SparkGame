using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointScript : MonoBehaviour
{
    public bool rotateLeft = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && !rotateLeft)
        {
            transform.Rotate(0, 180, 0);
            rotateLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && rotateLeft)
        {
            transform.Rotate(0, 180, 0);
            rotateLeft = false;
        }
    }
}
