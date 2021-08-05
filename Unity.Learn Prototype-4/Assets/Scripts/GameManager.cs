using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    public GameObject restartPanel;
    public TextMeshProUGUI finalScore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        finalScore.text = "Score: " + score.ToString();
    }
    public void OnStartButtonClick()
    {
        isGameActive = true;
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        restartPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
