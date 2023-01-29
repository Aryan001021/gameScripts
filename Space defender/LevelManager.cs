using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void StartGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
       StartCoroutine(LoadGameOverScene());
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
}
