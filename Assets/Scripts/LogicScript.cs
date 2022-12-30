using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource scorePingAudioSource;

    private bool isGameOver = false;
    
    [ContextMenu("Increment Score")]
    public void AddScore(int scoreToAdd)
    {
        if (!isGameOver)
        {
            scorePingAudioSource.Play();
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();   
        }
    }

    public void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        
        highScoreText.text = $"High score: {highScore}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        
        int highScore = PlayerPrefs.GetInt("HighScore");

        if (playerScore > highScore)
        {
            highScoreText.text = $"High score: {playerScore.ToString()}";
            
            PlayerPrefs.SetInt("HighScore", playerScore);    
        }
        
        gameOverScreen.SetActive(true);
    }
}
