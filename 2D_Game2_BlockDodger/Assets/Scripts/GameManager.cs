using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI StartText;
    public TextMeshProUGUI ScoreText;
    int score;

    public GameObject block;
    float maxX = 2;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Block.OnBlockDestroyed += HandleBlockDestroyed;
        ScoreText.enabled = false;
        score = 0;
        StartText.enabled = true;
    }

    private void HandleBlockDestroyed()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0)) { 
            StartText.enabled = false;
            ScoreText.enabled = true;
            gameStarted = true;
            startSpawn();
        }
    }

    private void startSpawn() {
        InvokeRepeating("spawnBlocks", 0.5f, spawnRate);
    }
    void spawnBlocks() {
        Vector2 spawnPosition = spawnPoint.position;
        spawnPosition.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPosition, Quaternion.identity);
    }
}
