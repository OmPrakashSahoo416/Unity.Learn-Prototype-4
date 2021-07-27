using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f;
    private GameObject player;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - gameObject.transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision player)
    {
        Vector3 lookDirection = (player.transform.position - gameObject.transform.position).normalized;
        if (player.gameObject.CompareTag("Player")) {

            player.rigidbody.AddForce(lookDirection*2.5f,ForceMode.Impulse);
        
        }
        if(player.gameObject.CompareTag("FirePower"))
        {
            enemyRb.AddForce(lookDirection * 100f, ForceMode.Impulse);
        }
    }
}
