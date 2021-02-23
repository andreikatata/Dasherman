using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupport : MonoBehaviour
{
    [Header("Life Stats")]
    
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    float speed;
    Player playerScript;
    [SerializeField] int heal;





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
    void OnTriggerEnter2D(Collider2D healPlayer)
    {
        if (healPlayer.tag == "Player")
        {
            playerScript.AddHealth();
            Destroy(gameObject);
        }
        
        
        if (healPlayer.tag == "Ground")
        {
            
            Destroy(gameObject);
            

        }

    }

    

 
   
}
