using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PapersPleaseMinigame papersMinigame;
    
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public GameData gameData;

    public IEnumerator LoadMainScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }

    public IEnumerator LoadLoseScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3);
    }

    public IEnumerator LoadWinScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }
}
