using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    float minAltitude = -6f;
    public static event Action OnBlockDestroyed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f) {
            OnBlockDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
