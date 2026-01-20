using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    public float coinRotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void FixedUpdate()
    {
        transform.Rotate(coinRotationSpeed, 0, 0);
    }
}
