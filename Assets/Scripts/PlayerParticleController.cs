using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour {

    private ParticleSystem basicParticle, deathParticle;


	private void Start () {
        InitializeParticles();
        basicParticle.Play();
	}

    private void InitializeParticles()
    {
        basicParticle = GameObject.FindGameObjectWithTag("BasicParticle").GetComponent<ParticleSystem>();
        deathParticle = GameObject.FindGameObjectWithTag("DeathParticle").GetComponent<ParticleSystem>();
    }

    private void SetBasicParticleColor(GameObject obj)
    {
        Color tempColor = GetColor(obj);
        tempColor.a = 1f;
        SetColor(basicParticle, tempColor);
    }

    public void PlayDeathParticle()
    {
        SetColor(deathParticle, GetColor(basicParticle));
        basicParticle.Stop();
        deathParticle.Play();
    }

    private Color GetColor(GameObject obj)
    {
        return obj.GetComponent<Renderer>().material.color;
    }

    private Color GetColor(ParticleSystem obj)
    {
        return obj.GetComponent<Renderer>().material.color;
    }

    private void SetColor(GameObject obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }

    private void SetColor(ParticleSystem obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }
}