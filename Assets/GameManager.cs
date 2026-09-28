using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    [Header("UI")]
    public TMP_Text roundText;
    public GameObject gameOverPanel;

    void Awake()
    {
        S = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        roundText.text = "Round 1";
        gameOverPanel.SetActive(false);

    }

    public void SetRound(int round)
    {
        if (round >= 1 && round <= 4)
        {
            roundText.text = "Round " + round;
        }
    }

    public void GameOver()
    {
        roundText.text = "Game Over";
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {   
        Time.timeScale = 1f;
        Debug.Log("RESTART GAME WAS CALLED!");
        SceneManager.LoadScene("_Scene_0");
    }
}