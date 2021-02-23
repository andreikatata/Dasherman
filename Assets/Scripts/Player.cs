using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    [Header("UI")]
    public Text healthDisplay;
    public GameObject loseScreen;
    public Text ScoreText;
    private float score;
    private float timer;

    [Header("Player stats")]
    [SerializeField] float speed;
    [SerializeField] float health;

    [Header("Dash Abillity")]
    [SerializeField] float startDashTime;
    [SerializeField] float extraSpeed;
    private bool isDashing;
    private float dashTime;
 
    private float input;
    Rigidbody2D rb;
    Animator anim;

    [Header("Particle")]
    public GameObject deathFX;
    public GameObject dashFX;

    
    public Image imageCooldown;
    public float cooldown = 5;
    bool isCooldown;

    AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        healthDisplay.text = health.ToString();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = health.ToString();
        imageCooldown.fillAmount = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        Dash();
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false && isCooldown == false)
        {
            //

            isCooldown = true;
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
            /*StartCoroutine(CoolDown());*/
        }
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }


        

    }
    /*IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(3f);
        isDashing = true;
    }*/

    private void Dash()
    {
        if (dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extraSpeed;
            Instantiate(dashFX, transform.position, Quaternion.identity); // vfx
        }

        else
        {
            dashTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        //score points per sec
        /*Timer();*/
        // Storing player's input
        input = Input.GetAxis("Horizontal");

        //Moving player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

   /* private void Timer()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            // Analytics for the score
            AnalyticsResult analyticsResult = Analytics.CustomEvent("HighScore" + "Game");
            Debug.Log("Score: " + analyticsResult);
            // 
            score += 100f;
            ScoreText.text = " Score: " + score.ToString();
            timer = 0f;
        }
    }*/

    public void TakeDamage(int damageAmount)
    {
        source.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            loseScreen.SetActive(true); // when the playing dies the lose screen goes active
            Destroy(gameObject);
        }
    }

    public void AddHealth()
    {
        health++;
        healthDisplay.text = health.ToString();

        
    }
    
}
