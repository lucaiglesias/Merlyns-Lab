using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private AsyncOperation async;
    public GameObject Panel_GameOver;
    public GameObject Panel_Menu;
    public GameObject Panel_NextLevel;

    private float oldTime = 0f;

    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        Panel_GameOver.SetActive(false);
        Panel_Menu.SetActive(false);
        Panel_NextLevel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !gameOver)
        {
            Pause_Game();

            Panel_Menu.SetActive(!Panel_Menu.activeSelf);

        }
    }

    private float Pause_Game()
    {
        float temp = oldTime;
        oldTime = Time.timeScale;
        Time.timeScale = temp;
        return temp;
    }


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GameOver(GameObject player)
    {
        if (!gameOver)
        {

            Destroy(player);
            Pause_Game();
            Panel_GameOver.SetActive(true);
            gameOver = true;

        }

    }

    public void Next_Level(GameObject player)
    {
        Destroy(player);
        if (Time.timeScale != 0f)
        {
            Pause_Game();
        }
        Panel_NextLevel.SetActive(true);
        gameOver = true;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }

    public void LoadNextScene(string name)
    {
        if (Time.timeScale == 0f)
        {
            Pause_Game();
        }

        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(name);
        }
    }

}
