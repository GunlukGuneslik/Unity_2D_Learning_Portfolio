using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    bool gameIsOver;
    int health;
    bool waitForDamage;
    public GameObject[] harts;
    int initialCoins;
    int currentCoins;
    public float speed;
    float x;

    Rigidbody2D rb;
    Animator anim;
    public AudioClip coinSound;
    public AudioClip damageSound;
    AudioSource audioSource;
    public TextMeshProUGUI lostMessage;
    public TextMeshProUGUI WinMessage;
    public TextMeshProUGUI infoMessage;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float jumForce;
    float doublJumFroce;
    bool doubleJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        doubleJump = true;
        doublJumFroce = jumForce - 1;
        health = (harts.Length > 0)? (harts.Length - 1):-1;
        waitForDamage = false;
        gameIsOver = false;

        lostMessage.enabled = false;
        WinMessage.enabled = false;
        infoMessage.enabled = false;

        initialCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        currentCoins = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (health < 0) {
            gameIsOver = true;
            lostMessage.enabled = true;
            infoMessage.enabled = true;
        } else if (currentCoins > initialCoins) {
            gameIsOver = true;
            WinMessage.enabled = true;
            infoMessage.enabled = true;
        }

        if (gameIsOver && Input.GetKeyDown(KeyCode.Space)) { 
            redownloadScene();
        }

        if (!gameIsOver)
        {
            x = Input.GetAxisRaw("Horizontal");
            CheckDirection();
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumForce);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, doublJumFroce);
                doubleJump = false;
            }

            if (isGrounded)
            {
                doubleJump = true;
                if (!waitForDamage && health >= 0 && rb.linearVelocity.y < -10f)
                {
                    damage();
                    waitForDamage = true;
                }
                else if (rb.linearVelocity.y > -10f)
                {
                    waitForDamage = false;
                }
            }

            anim.SetBool("IsGrounded", isGrounded);
            anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

            //temp.text = "" + rb.linearVelocity.y;
        }
    }

    private void redownloadScene() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        //transform.Translate(x, 0, 0);
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }

    void CheckDirection() {
        if (rb.linearVelocity.x < 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (rb.linearVelocity.x > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void damage() {
        audioSource.PlayOneShot(damageSound);
        Destroy(harts[health]);
        health--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin") {
            currentCoins++;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(coinSound);
        } else if (health >= 0 && collision.gameObject.tag == "Mushroom") {
            damage();
            Destroy(collision.gameObject);
        }
    }
}
