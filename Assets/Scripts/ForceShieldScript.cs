using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShieldScript : MonoBehaviour
{
    public BossScript bossScript;
    public Collider2D col;
    public SpriteRenderer sprite;
    void Update()
    {
        if(bossScript.life <= 0)
        {
            col.enabled = false;
            sprite.enabled = false;
        }
    }
    public void Activate()
    {
        StartCoroutine(Deactivate(10));
    }
    private IEnumerator Deactivate(float duration)
    {
        col.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSecondsRealtime(duration);
        col.enabled = true;
        sprite.enabled = true;
    }
}
