using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    /// <summary>
    //Game Manager loads in to fire this panel open, and then try to use buttons in UI to trigger shit. like dominoes!!!
    /// </summary>

    public GameObject currentState;
    public static int StateTick;
    public int _currentState;

    public GameObject Panel; //pause panel, currently


    void Awake()
    {
        //collectBrick = GetComponent<CollectBrick>();

        currentState.GetComponent<Text>().text = "State = " + StateTick;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();

        }
 
    }
    public void Play()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        //! in !Panel.gameObject.activeSelf makes this just a toggle. 
 
        Time.timeScale = 0; //stops game time
        Panel.gameObject.SetActive(!Panel.gameObject.activeSelf); //opens pause menu

    }

    public void ResetLevel()
    {
        UnityEngine.Debug.Log("We Reset Successfully");
        //loads the scene over, FMOD requires a restart funcion in here.
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //this works, but FMOD needs assist
    }
    public void QuitGame()
    {
        UnityEngine.Debug.Log("Quit!");
        Application.Quit();
    }


}

/*
        on key.Down(esc){PauseGame;}
        if (totalBrick = GoalBrickCt){pauseGame(); UI.counters=active; }
        if (totalTime = EndTime);{pauseGame(); UI.reload=active; 
        if (totalBrick != GoalBrickCT && TotalTime);{pauseGame(); UI.reload
        if (UI.main = true); {main}

    public void OpenPanel()
    {
        if (Panel ! = null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(isActive);
        }
    }



 */