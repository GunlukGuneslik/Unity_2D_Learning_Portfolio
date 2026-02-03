using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI lostText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI socreText;
    public GameObject target;

    private int score;
    public int winScore;
    
    public bool gameContinue;
    public AudioSource AudioSource;

    void Awake()
    {
        instance = this;
        AudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        gameContinue = true;
        lostText.enabled = false;
        winText.enabled = false;
        // A default winScore
        if (winScore <= 0) {
            winScore = 20;
        }
        socreText.text = "" + score;
        score = 0;
        InvokeRepeating("Spawn",1f, 2f);
    }

    // Update is called once per frame
    void Update(){
        if (score >= winScore) {
            winGame();
        }

        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.Play();
        }
    }


    public void increaseScore() {
        score++;
        socreText.text = "" + score;
    }

    private void Spawn()
    {
        float x = Random.Range(-7f,7f);
        float y = Random.Range(-3.5f,3.5f);

        Vector3 position = new Vector3(x,y,0);
        Instantiate(target, position, Quaternion.identity);
    }

    public void EndGame() {
        gameContinue = false;
        CancelInvoke("Spawn");
        lostText.enabled = true;
    }

    public void winGame() {
        gameContinue = false;
        CancelInvoke("Spawn");
        winText.enabled = true;
    }

}
