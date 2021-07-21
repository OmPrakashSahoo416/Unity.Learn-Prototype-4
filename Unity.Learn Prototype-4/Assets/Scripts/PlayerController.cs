using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool isPowerUp;
    private float powerUpStrength = 15f;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*speed*verticalMovement);
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCounter());
        }

    }
    
    IEnumerator PowerUpCounter()
    {
        yield return new WaitForSeconds(5);
        powerUpIndicator.SetActive(false);
        isPowerUp = false;
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
