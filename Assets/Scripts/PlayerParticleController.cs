using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    private ParticleSystem basicParticle, deathParticle;

	private void Start ()
    {
        initializeParticles();
        basicParticle.Play();
	}

    private void initializeParticles()
    {
        basicParticle = GameObject.FindGameObjectWithTag("BasicParticle").GetComponent<ParticleSystem>();
        deathParticle = GameObject.FindGameObjectWithTag("DeathParticle").GetComponent<ParticleSystem>();
    }

    private void setBasicParticleColor(GameObject obj)
    {
        Color tempColor = getColor(obj);
        tempColor.a = 1f;
        setColor(basicParticle, tempColor);
    }

    public void playDeathParticle()
    {
        setColor(deathParticle, getColor(basicParticle));
        basicParticle.Stop();
        deathParticle.Play();
    }

    private Color getColor(GameObject obj) { return obj.GetComponent<Renderer>().material.color; }

    private Color getColor(ParticleSystem obj) { return obj.GetComponent<Renderer>().material.color; }

    private void setColor(GameObject obj, Color color) { obj.GetComponent<Renderer>().material.color = color; }

    private void setColor(ParticleSystem obj, Color color) { obj.GetComponent<Renderer>().material.color = color; }
}