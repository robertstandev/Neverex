using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]private Mesh[] meshes;
    [SerializeField]private Material[] playerMaterials;
    [SerializeField]private ParticleSystem collisionParticle, tokenParticle;
    [SerializeField]private ParticleSystemRenderer basicParticleRenderer, deathParticleRenderer;

    private bool gameIsOver = false;

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
                Invoke("enableCollider", 0.1f);
                FindObjectOfType<ScoreManager>().incrementScore();
                FindObjectOfType<AudioManager>().playScoreSound();
                spawnCollisionParticle();
            }
            else
            {
                gameIsOver = true;
                deathParticleRenderer.material = playerRenderer.material;
                FindObjectOfType<PipeMove>().stopPipes();
                FindObjectOfType<AudioManager>().playDeathSound();
                FindObjectOfType<GameManager>().endPanelActivation();
                FindObjectOfType<Spawner>().enabled = false;
                stopPlayer();

                GetComponent<Collider>().enabled = false;
            }
        }
        else if (other.CompareTag("Token"))
        {
            FindObjectOfType<AudioManager>().playTokenSound();
            FindObjectOfType<ScoreManager>().incrementToken();
            Destroy(other.gameObject);
            spawnTokenParticle();
        }
    }

    private void enableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void stopPlayer()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<PlayerParticleController>().playDeathParticle();
    }

    private void spawnCollisionParticle()
    {
        ParticleSystem tempParticle = Instantiate(collisionParticle, transform.position, Quaternion.identity);
        tempParticle.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        tempParticle.Play();
        Destroy(tempParticle.gameObject, 1f);
    }

    private void spawnTokenParticle()
    {
        ParticleSystem tokenPar = Instantiate(tokenParticle, transform.position, Quaternion.identity);
        Destroy(tokenPar.gameObject, 1f);
    }

    public bool isGameOver()
    {
        return this.gameIsOver;
    }
}
