using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public GameStateManager gameStateManager;

    // Gets the gameStateManager
    void Start()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameStateManager>();
    }

    // Adds score when the player goes through the empty space in the middle of the pipe
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) {
            gameStateManager.addScore(1);
        }
    }
}
