using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public int score = 0;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject player;
    public GameObject spawner;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private Vector3 startPos;
    public float amplitude = 1f;
    public float frequency = 1f;

    public AudioSource audioSource;
    public AudioClip deathSound;
    public AudioClip scoreSound;

    // Used to get the startPos of the title screen
    void Start()
    {
        startPos = titleScreen.transform.position;
    }

    // Used to shift the title screen up and down in a sine motion as long as the player is on the title screen
    void Update()
    {
        if(titleScreen.activeSelf)
        {
            titleScreen.transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * frequency) * amplitude, 0);
        }
        
    }

    // Adds scoreToAdd to the current score and updates the UI
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) 
    {
        if (!gameOverScreen.activeSelf) 
        {
            audioSource.PlayOneShot(scoreSound);
            score += scoreToAdd;
            scoreText.text = score.ToString();
        }
    }

    // Reloads the current scene to restart the game
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Activates the game over screen while updating the high score and hiding the score UI
    public void gameOver()
    {
        if (gameOverScreen != null) 
        {
            updateHighScore();
            gameOverScreen.SetActive(true);
            scoreText.gameObject.SetActive(false);
            audioSource.volume = 0.1f; 
            audioSource.PlayOneShot(deathSound);
        }
    }

    // Activates the player and spawner and deactivates the title screen when the start button is pressed
    public void startGame()
    {
        if (titleScreen != null) 
        {
            titleScreen.SetActive(false);
            player.SetActive(true);
            spawner.SetActive(true);
            scoreText.gameObject.SetActive(true);
        }
    }

    // Uses playerPrefs to save the high score
    public void updateHighScore() 
    {
        if (PlayerPrefs.HasKey("SavedHighScore")) 
        {
            if (score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }

        highScoreText.text = "Score: " + score.ToString() + "\n" + "Highscore: " +PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

}
