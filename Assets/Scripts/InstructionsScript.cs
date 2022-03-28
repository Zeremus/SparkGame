using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsScript : MonoBehaviour
{
    [SerializeField] Text textOne;
    [SerializeField] Text textTwo;
    [SerializeField] Text textThree;
    void Update()
    {
        if(textThree.enabled == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                textThree.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(textOne.enabled == true)
            {
                textTwo.enabled = true;
                textOne.enabled = false;
                Destroy(gameObject);
            }
            else if(textTwo.enabled == true)
            {
                textTwo.enabled = false;
                textThree.enabled = true;
                Destroy(gameObject);
            }
            
        }
    }
}
