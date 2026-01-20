using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Block : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public AudioClip breakSound;
    PaddleController Paddle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start(){
        Paddle = FindAnyObjectByType<PaddleController>();
    }

    // Update is called once per frame
    void Update(){}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball"){
            GameManager.Instance.decreaseBlockNumber();
            if (Paddle != null)
            {
                Paddle.changeCollor(spriteRenderer.color);
            }
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
            Destroy(this.gameObject);
        }
    }
}
