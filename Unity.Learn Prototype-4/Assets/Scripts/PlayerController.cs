using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool isPowerUp;
    public bool isFire;
    private float powerUpStrength = 25f;
    public GameObject powerUpIndicator;
    public GameObject bulletPrefab;
    private Rigidbody bulletRb;
    public Vector3 firePointOffset;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        bulletRb = GameObject.Find("Bullet").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward*speed*verticalMovement);
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);

        if(isFire)
        {
            Instantiate(bulletPrefab,transform.position + firePointOffset,bulletPrefab.transform.rotation);
            
        }
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
        if(other.CompareTag("FirePower"))
        {
            isFire = true;
            Destroy(other.gameObject);
            StartCoroutine(FirePowerCounter());
            //do something...
        }

    }
    
    IEnumerator PowerUpCounter()
    {
        yield return new WaitForSeconds(5);
        powerUpIndicator.SetActive(false);
        isPowerUp = false;
    }
    IEnumerator FirePowerCounter()
    {
        yield return new WaitForSeconds(8);
        isFire = false;
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
