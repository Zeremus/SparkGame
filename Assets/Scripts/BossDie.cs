using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.4f);
    }
}
