using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public Mesh[] meshes;
    public Material[] playerMaterials;
    public ParticleSystem collisionParticle, tokenParticle;
    public ParticleSystemRenderer basicParticleRenderer, deathParticleRenderer;

    [HideInInspector]
    public bool gameIsOver = false;

    private MeshFilter playerMesh;
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerMesh = GetComponent<MeshFilter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube Instance") || other.CompareTag("Sphere Instance") || other.CompareTag("Prism Instance"))
        {
            if (other.CompareTag(GetComponent<MeshFilter>().mesh.name))
            {
                basicParticleRenderer.material = playerRenderer.material = playerMaterials[Random.Range(0, playerMaterials.Length)];
                GetComponent<Collider>().enabled = false;
                playerMesh.mesh = meshes[Random.Range(0, meshes.Length)];
                Invoke("EnableCollider", 0.1f);
                FindObjectOfType<ScoreManager>().IncrementScore();
                FindObjectOfType<AudioManager>().ScoreSound();
                SpawnCollisionParticle();
            }
            else
            {
                gameIsOver = true;
                deathParticleRenderer.material = playerRenderer.material;
                FindObjectOfType<PipeMove>().StopPipes();
                FindObjectOfType<AudioManager>().DeathSound();
                FindObjectOfType<GameManager>().EndPanelActivation();
                FindObjectOfType<Spawner>().enabled = false;
                StopPlayer();

                GetComponent<Collider>().enabled = false;
            }
        }
        else if (other.CompareTag("Token"))
        {
            FindObjectOfType<AudioManager>().TokenSound();
            FindObjectOfType<ScoreManager>().IncrementToken();
            Destroy(other.gameObject);
            SpawnTokenParticle();
        }
    }

    public void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void StopPlayer()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<PlayerParticleController>().PlayDeathParticle();
    }

    public void SpawnCollisionParticle()
    {
        ParticleSystem tempParticle = Instantiate(collisionParticle, transform.position, Quaternion.identity);
        tempParticle.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        tempParticle.Play();
        Destroy(tempParticle.gameObject, 1f);
    }

    public void SpawnTokenParticle()
    {
        ParticleSystem tokenPar = Instantiate(tokenParticle, transform.position, Quaternion.identity);
        Destroy(tokenPar.gameObject, 1f);
    }
}
