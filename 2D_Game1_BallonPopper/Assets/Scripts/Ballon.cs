using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ballon : MonoBehaviour
{

    public Image[] harts;
    int health;

    public float speed;
    int score = 0;

    float maxAltitude = 6f;
    float minAltitude = -6f;
    float minX = -2.23f;
    float maxX = 2.38f;

    AudioSource audioSource;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        health = harts.Length;
        for (int i = 0; i < health; i++) {
            harts[i].enabled = true;
        }
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxAltitude) {
            health--;
            harts[health].enabled = false;
            ResetPosition();
        }

        if (health <= 0) {
            //SceneManager.LoadScene("Game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    private void FixedUpdate()
    {
        // x ve z de hareket etmiyor
        transform.Translate(0, speed * Time.fixedDeltaTime, 0);
    }

    private void OnMouseDown()
    {
        score++;
        audioSource.Play();
        scoreText.text = "Score: " + score;
        ResetPosition(); 
    }

    private void ResetPosition() { 
        float Xposition = Random.Range(minX, maxX);
        transform.position = new Vector2(Xposition, minAltitude);
    }
}
