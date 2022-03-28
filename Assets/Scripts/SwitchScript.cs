using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject bridge;
    public SpriteRenderer spriteRenderer;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "FireBall")
        {
            spriteRenderer.color = Color.red;
            bridge.SetActive(true);
        }
    }
}
