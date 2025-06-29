using UnityEngine;

public class Coin : MonoBehaviour
{
    private  AudioSource CoinSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
CoinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
            GameManager.score += 1; // Increment the score by 1
            CoinSound.Play(); // Play the coin sound
        }
    }
}