using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool isPowerUp;
    private float powerUpStrength = 25f;
    public GameObject powerUpIndicator;
    public GameObject restartPanel;
    public GameManager gameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
      
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*speed*verticalMovement);
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);

        if (transform.position.y < -5f)
        {
            restartPanel.SetActive(true);
            Time.timeScale = 0f;
                   
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            powerUpIndicator.SetActive(true);
            gameManagerScript.score += 5;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCounter());

        }

        IEnumerator PowerUpCounter()
        {
            yield return new WaitForSeconds(5);
            powerUpIndicator.SetActive(false);
            isPowerUp = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 powerUpDirection = collision.gameObject.transform.position - gameObject.transform.position;
            enemyRigidBody.AddForce(powerUpDirection * powerUpStrength, ForceMode.Impulse);
        }
    }
    
}
