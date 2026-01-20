using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public TextMeshProUGUI currentScoreText;
    public GameObject gameStartUI;

    public GameObject scoreUI;
    public GameObject starImage;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;


    public BallContorller ball;
    
    static bool firstTime = true;
    static int bestScore = 0;
    static bool gameIsActive = false;
    int score;
    int blockNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Instance = this;
        score = 0;
        scoreText.text = "" + 0;
    }
    void Start()
    {
        scoreUI.SetActive(false);
        gameStartUI.SetActive(false);

        blockNumber = GameObject.FindGameObjectsWithTag("Block").Length;
        if (!gameIsActive && firstTime)
        {
            gameStartUI.SetActive(true);
            ball.frozeBall();
        } else if (!gameIsActive) { 
            scoreUI.SetActive(true);
            ball.frozeBall();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameIsActive && blockNumber <= 0) {
            GameOver();
        }

        if (!gameIsActive && Input.anyKeyDown) {
            if (!firstTime)
            {
                Restart();
            }
            else {
                firstTime = false;
                GameStart();
            }
        }
    }

    private void GameStart() {
        gameIsActive = true;
        gameStartUI.SetActive(false);
        scoreUI.SetActive(false);
        ball.unfrozeBall();
    }

    public void GameOver() {
        gameIsActive = false;
        starImage.SetActive(false);
        if (score > bestScore)
        {
            bestScore = score;
            starImage.SetActive(true);
        }
        scoreText.text = "" + score;
        bestScoreText.text = "" + bestScore;
        scoreUI.SetActive(true);
        ball.frozeBall();
    }
    public void Restart() {
        gameIsActive = true;
        SceneManager.LoadScene("Game");
    }

    public void decreaseBlockNumber (){
        blockNumber--;
    }
    public void increaseScore() {
        score++;
        currentScoreText.text = "" + score;
    }
}
