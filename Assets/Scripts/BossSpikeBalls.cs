using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpikeBalls : MonoBehaviour
{
    public BossScript bossScript;

    // Update is called once per frame
    void Update()
    {
        if(bossScript.life <= 0) gameObject.SetActive(false);
    }
}
