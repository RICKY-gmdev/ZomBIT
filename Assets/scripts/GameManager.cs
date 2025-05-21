using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int score = 0;
    public Text scoreText;

    public void IncreaseScore()
    {
        score=score+10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        
    }
}
