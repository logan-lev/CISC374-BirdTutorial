using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float jumpForce = 10.0f;

    public GameStateManager gameStateManager;

    public AudioSource audioSource;
    public AudioClip flapSound;

    public bool isAlive = true;

    // Sets gameStateManager to the object with the tag "Manager"
    void Start()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameStateManager>();
    }

    // Allows the player to jump each time the space bar is pressed while the player is alive
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive) {
            audioSource.volume = 1.5f;
            audioSource.PlayOneShot(flapSound);
            Jump();
        }
    }

    // Allows the player to jump on each call
    private void Jump() 
    {
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
    }

    // Activates the game over screen if the player collides with an obstacle and sets isAlive to false
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            gameStateManager.gameOver();
            isAlive = false;
        }
    }
    
    // Activates the game over screen if the player leaves the screen and sets isAlive to false
    void OnBecameInvisible()
    {
        gameStateManager.gameOver();
        isAlive = false;
    }
}
