using NUnit.Framework.Internal;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    public float maxSize_x;
    public float growthSpeed;
    //public GameObject gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < maxSize_x)
        {
            if (GameManager.instance.gameContinue) {
                Vector3 growthVector = (new Vector3(1, 1, 0)) * growthSpeed * Time.deltaTime;
                transform.localScale += growthVector;
            }
        }
        else {
            GameManager.instance.EndGame();
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.gameContinue)
        {
            GameManager.instance.increaseScore();
            Destroy(gameObject);
        }
    }
}
