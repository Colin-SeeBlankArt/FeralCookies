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

    public GameObject NextLevel;    //win level panel
    public GameObject PausePanel; //pause panel, currently
    public GameObject EndTime; //end time panel, currently
    
    //instaniate bunny!!
    public float _makeB = 2f; //spawn red bunny
    public float _makeBg = 2f; //spawn good bunny
    public float _makeRover = 1f;
    private float elapsed;
    private float _roverElapsed;
    public GameObject rover;
    public GameObject bunny;
    public GameObject bunnyG;
    public GameObject _sMSegs; //SheetMusic Testing Instantiate coins w/ rules
    public static int _noteQuota = 0; //coming from scoring system, until better idea
    public static int _pause = 0;
    public static bool _endTime = false;

    int _pauseMe = 0;

    //test to find this out. May need to be Public in PlayerCtrl
    float minSpeed;
    float maxSpeed;

    void Awake()
    {
        _noteQuota = 0;
        currentState.GetComponent<Text>().text = "State = " + StateTick;
        Play();
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
            MakeGoodBunny();
        }

        _roverElapsed += Time.deltaTime;
        if (_roverElapsed >= _makeRover)
        {
            _roverElapsed = 0f;
            MakeRover();
        }

        if (_noteQuota == 1)
        {
            WinGame();
        }
         if(_endTime == true)
        {
            EndTimer();
        }
    }
    public void WinGame()
    {
        ScoringSystem.RecordResults();
        NextLevel.gameObject.SetActive(!NextLevel.gameObject.activeSelf); //opens pause menu
        Debug.Log("Win Game!");
        Time.timeScale = 0;
        audioBox._pause++;
    }

    public void Play()
    {
        Time.timeScale = 1;
        audioBox._pause = 0;
    }
    public void PauseGame()
    {
        Time.timeScale = 0; //stops game time
        PausePanel.gameObject.SetActive(!PausePanel.gameObject.activeSelf); //opens pause menu  
        audioBox._pause++;
        _pauseMe++;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1; //start game time
        LoopMachine._pause = 0;
        audioBox._pause = 0;
        _pauseMe = 0;
    }
    public void EndTimer()
    {
        Time.timeScale = 0; //stops game time
        //EndTime.gameObject.SetActive(!EndTime.gameObject.activeSelf); //opens pause menu
        EndTime.gameObject.SetActive(true);
    }
    public void ResetLevel()
    {
        UnityEngine.Debug.Log("We Reset Successfully");
        //loads the scene over, audio needs to persist
        //maybe it should pause since its game crit
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoringSystem._resetALL ++;
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

    public void MakeGoodBunny()
    {
        Instantiate(bunnyG, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void MakeRover()
    {
        Instantiate(rover, new Vector3(0, 0, 0), Quaternion.identity);
        //Debug.Log("Rover is Not Working");
    }


    private async void Start()
    {
        await AnalyticsManager.InitializeAsync();
    }


}

/*
 * 
 *      
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