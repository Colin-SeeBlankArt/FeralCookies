using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject currentState;
    public static int StateTick;
    public int _currentState;

    public GameObject Panel; //pause panel, currently

    //instaniate bunny!!
    public float _makeB = 2f; //spawn every x seconds, hopefully
    private float elapsed;
    public GameObject bunny;

    public GameObject _sMSegs; //SheetMusic Testing Instantiate coins w/ rules

    public static int _noteQuota = 0; //coming from scoring system, until better idea

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
        //loads the scene over, audio needs to persist
        //maybe it should pause since its game crit
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
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