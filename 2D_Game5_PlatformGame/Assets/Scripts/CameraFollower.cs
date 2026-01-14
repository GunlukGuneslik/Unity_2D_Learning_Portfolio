using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform player;
    public float smoothRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update(){}

    private void FixedUpdate()
    {
        Vector3 playerPos = player.position;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerPos.x, smoothRate),
                                            Mathf.Lerp(transform.position.y, playerPos.y, smoothRate),
                                            transform.position.z);

    }
}
