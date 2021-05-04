using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]private Mesh[] meshes;
    [SerializeField]private Material[] playerMaterials;
    [SerializeField]private ParticleSystem collisionParticle, tokenParticle;
    [SerializeField]private ParticleSystemRenderer basicParticleRenderer, deathParticleRenderer;

    private ScoreManager scoreManagerComponent;
    private AudioManager audioManagerComponent;
    private PipeMove pipeMoveComponent;
    private GameManager gameManagerComponent;
    private Spawner spawnerComponent;
    private PlayerMovement playerMovementComponent;
    private PlayerParticleController playerParticleControllerComponent;

    private bool gameIsOver = false;

    private MeshFilter playerMesh;
    private Renderer playerRenderer;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        playerMesh = GetComponent<MeshFilter>();
        scoreManagerComponent = FindObjectOfType<ScoreManager>();
        audioManagerComponent = FindObjectOfType<AudioManager>();
        pipeMoveComponent = FindObjectOfType<PipeMove>();
        gameManagerComponent = FindObjectOfType<GameManager>();
        spawnerComponent = FindObjectOfType<Spawner>();
        playerMovementComponent = FindObjectOfType<PlayerMovement>();
        playerParticleControllerComponent = FindObjectOfType<PlayerParticleController>();
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
                scoreManagerComponent.incrementScore();
                audioManagerComponent.playScoreSound();
                spawnCollisionParticle();
            }
            else
            {
                gameIsOver = true;
                deathParticleRenderer.material = playerRenderer.material;
                pipeMoveComponent.stopPipes();
                audioManagerComponent.playDeathSound();
                gameManagerComponent.endPanelActivation();
                spawnerComponent.enabled = false;
                stopPlayer();

                GetComponent<Collider>().enabled = false;
            }
        }
        else if (other.CompareTag("Token"))
        {
            audioManagerComponent.playTokenSound();
            scoreManagerComponent.incrementToken();
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
        playerMovementComponent.enabled = false;
        playerParticleControllerComponent.playDeathParticle();
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
