using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    //from Brackey's - Load screen
    // https://www.youtube.com/watch?v=YMj2qPq9CP8
    //
    public void LoadLevel (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        StartCoroutine(LoadAsynchronously(sceneIndex)); //CoRoutine Function
    }
    //CoRoutine to run the load of one scene while another scene is running
    IEnumerator LoadAsynchronously (int sceneIndex)
    {   
        //Operation is the var holding the loading progress in the scene index
        //While loop just says on this frame, tell us the progress, 
        //then at the end of this frame, go to the next frame, repeat until done 

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log (progress);
            yield return null;  
        }
    }

    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeScene(int sceneIndex) //change by name
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void UI_Pop () // use this to test out ideas for "popping" menus telling the player "something" happened
    {
        //create simple 3 sec time, sec 1 fade in, sec 2 read text, sec 3 fade out
        //animate text stating "Pop!" after coin collect
        //animate text stating "Loop Collected", bring in LoopCt from GameManager
    }

    public void FadeFromBlack()
    {
        anim.SetBool("FromBlack", true);
    }
}

