using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_ParticleDoor : MonoBehaviour
{
    public ParticleSystem particle;
    public GameManager gameManager;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (gameManager.playParticleDoor_1st == true)
            {
                particle.Play();
                gameManager.playParticleDoor_1st = false;

            }
            if (gameManager.playParticleDoor_2rd == true)
            {
                particle.Play();
                gameManager.playParticleDoor_2rd = false;
            }
            if (gameManager.playParticleDoor_3nd == true)
            {
                particle.Play();
                gameManager.playParticleDoor_3nd = false;
            }
        }
    }
}
