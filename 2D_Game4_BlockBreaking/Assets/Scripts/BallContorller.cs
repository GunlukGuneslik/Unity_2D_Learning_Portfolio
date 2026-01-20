using UnityEngine;

public class BallContorller : MonoBehaviour
{
    Rigidbody2D rb;
    public float minVelocity;
    public float maxVelocity;
    public float bounceForce;
    public AudioClip hitSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        minVelocity = Mathf.Abs(minVelocity);
        maxVelocity = Mathf.Abs(maxVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(rb.linearVelocity.x) < 0.1f)
        {
            bounceRandom();
        }

        if (rb.linearVelocity.magnitude < minVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * minVelocity;
        } else if (rb.linearVelocity.magnitude > maxVelocity) {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }


        if (collision.gameObject.tag == "BottomBoundary")
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        } else if (collision.gameObject.tag == "Block") {
            GameManager.Instance.increaseScore();
        }
    }

    void bounceRandom() {
        Vector2 force = new Vector2(Random.Range(-2,2), 0) * bounceForce;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void bounce() {
        rb.linearVelocity = new Vector2( rb.linearVelocity.x, rb.linearVelocity.y) * (-1);
    }

    public void frozeBall() {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
    }

    public void unfrozeBall() {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
