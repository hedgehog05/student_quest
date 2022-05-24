using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject pencilGun;
    public GameObject book;

    public static bool GameIsStarted = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // если ранее активированы карандаши
            if (pencilGun.activeInHierarchy == true)
            {
                //отключить
                pencilGun.SetActive(false);
                //активировать второй тип оружия
                book.SetActive(true);
            }
            //аналогично
            else if (book.activeInHierarchy == true)
            {
                book.SetActive(false);
                pencilGun.SetActive(true);
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameIsStarted)
            {
                pencilGun.SetActive(false);

                if (pencilGun.activeInHierarchy == true)
                {
                    pencilGun.SetActive(false);
                    book.SetActive(true);
                }

                else if (book.activeInHierarchy == true)
                {
                    book.SetActive(false);
                    pencilGun.SetActive(true);
                }
            }

        }*/
    }
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


	void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SaveGame()
    {
        Debug.Log("Saving game");
    }

    public void OpenSettings()
    {
        Debug.Log("Loading settings");
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu");
    }

    //public void QuitGame()
    //{
    //    Application.Qiut();
    //}
}
 */
