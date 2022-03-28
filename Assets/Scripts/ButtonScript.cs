using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject platform;
    private Animator animator;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            animator = platform.GetComponent<Animator>();
            animator.enabled = true;
        }
    }
}
