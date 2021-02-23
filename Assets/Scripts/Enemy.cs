using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int scoreValue = 150;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    float speed;
    Player playerScript;
    public int damage;

    public GameObject explosion;
    public GameObject playerHitParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        // random between min and max
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }

    // Update is called once per frame
    void Update()
    {
        
        //moving the object by -1 on the Y and making the framerate independent
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        // working with tags
        if (hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Instantiate(playerHitParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(hitObject.tag == "Ground")
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);

            
        }
    }
   
}
