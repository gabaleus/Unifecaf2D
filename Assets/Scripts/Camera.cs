using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= transform.position.x && player.transform.position.x <= transform.position.x + 10)
        {
            // Move the camera to the left
            transform.position = new Vector3(player.transform.position.x, 0, -10);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else if (player.transform.position.x < transform.position.x && player.transform.position.x >= transform.position.x - 10)
        {
            // Move the camera to the right
            transform.position = new Vector3(player.transform.position.x, 0, -10);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
