using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Dreamteck.Forever;

public class UI_Manager : MonoBehaviour
{
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeScene(int sceneIndex) //change by index
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeSceneName(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void StartPlayer()
    {
        //activate player in 3 secs after pressiong this button
        //LevelGen.Awake = true

    }
    public void FadeFromBlack()
    {
        anim.SetBool("FromBlack", true);
    }
    public void QuitGame()
    {
        UnityEngine.Debug.Log("Quit!");
        Application.Quit();
    }
    //from Brackey's - Load screen
    // https://www.youtube.com/watch?v=YMj2qPq9CP8
    //
    public void LoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        StartCoroutine(LoadAsynchronously(sceneIndex)); //CoRoutine Function
    }
    //CoRoutine to run the load of one scene while another scene is running
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //Operation is the var holding the loading progress in the scene index
        //While loop just says on this frame, tell us the progress, 
        //then at the end of this frame, go to the next frame, repeat until done 

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }
    }

}

