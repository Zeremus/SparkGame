using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnScript : MonoBehaviour
{
    public GameObject spikeBalls;
    public AudioSource music;
    public AudioSource bossMusic;
    public GameObject scareCrows;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(scareCrows);
            spikeBalls.SetActive(true);
            music.Stop();
            bossMusic.Play();
            Destroy(gameObject);
        }
    }
}
