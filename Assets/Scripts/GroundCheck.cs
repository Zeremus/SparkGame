using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerScript playerScript;
    public AudioSource land;
    void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            playerScript.isGrounded = true;
            land.Play();
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            playerScript.isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            playerScript.isGrounded = false;
        }
    }
}
