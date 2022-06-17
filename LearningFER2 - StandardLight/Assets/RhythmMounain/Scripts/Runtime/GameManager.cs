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

    //instaniate bunny!!
    public float _makeB = 2f; //spawn every x seconds, hopefully
    private float elapsed;
    public GameObject bunny;

    public static int _noteQuota = 0; //coming from scoring system, unitl better idea

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
 
        elapsed += Time.deltaTime;
        if (elapsed >= _makeB)
        {
            elapsed = 0f;
            MakeBunny();
        }

        if (_noteQuota == 1)
        {
            WinGame();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //this works, but FMOD needs assist
    }
    public void QuitGame()
    {
        UnityEngine.Debug.Log("Quit!");
        Application.Quit();
    }

    public void MakeBunny()
    {
        
        Instantiate(bunny, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void WinGame()
    {
        Panel.gameObject.SetActive(!Panel.gameObject.activeSelf); //opens pause menu
        Debug.Log("Win Game!");
        Time.timeScale = 0;

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