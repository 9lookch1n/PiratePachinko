using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_ParticleStar : MonoBehaviour
{
    public ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("Ball"):
                particle.Play();
                break;
        }
    }
}
