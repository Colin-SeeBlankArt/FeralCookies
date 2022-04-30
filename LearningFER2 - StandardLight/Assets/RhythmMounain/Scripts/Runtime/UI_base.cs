using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_base : MonoBehaviour
{
    private Animator _UIanim;

    private void Start()
    {
        _UIanim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _UIanim.SetBool("Sate_Color2", true);
    }
}

/*
    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public Slider slider; //rename to loop meeter

    public void SetMaxloopMeter(int loopMeter)
    {
        slider.maxValue = loopMeter;
        slider.minValue = loopMeter;
    }

    public void SetLoopCounter(int loopMeter)
    {
        slider.value = loopMeter;

    }
    */
