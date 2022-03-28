using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimScript : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void EndAnimation()
    {
        animator.enabled = false;
    }
}
