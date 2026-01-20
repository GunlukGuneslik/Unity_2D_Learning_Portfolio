using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PaddleController : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position = transform.position + new Vector2(1, 0) * speed;
            rb.linearVelocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position = transform.position - new Vector2(1, 0) * speed;
            rb.linearVelocity = Vector2.left * speed;
        }
        else { 
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void changeCollor( Color color) {
        spriteRenderer.color = color;
    }
}
