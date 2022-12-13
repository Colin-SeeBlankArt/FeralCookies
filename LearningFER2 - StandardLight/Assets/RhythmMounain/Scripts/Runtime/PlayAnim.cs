using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public static bool _musicTrig = false;

    //[SerializeField] private GameObject _stopTrigObj;
    //[SerializeField] private GameObject _startTrigObj;

    [SerializeField] private Animator _soundBox = null;
    [SerializeField] private bool Idle_trig = true;
    //[SerializeField] private
    public static bool BassA_trig = false;
    [SerializeField] private bool KeysA1_trig = false;
    
    [SerializeField] private string _bassA_Trigger = "Bass_A1_";
    [SerializeField] private string _idle_Trigger = "Idle";
    [SerializeField] private string _keysA1_Trigger = "KeysA1";

    private void Awake()
    {
        //_stopTrigObj.SetActive(false);
        //_startTrigObj.SetActive(true);
    }

    void Update()
    {
        if (BassA_trig)

        {
            _soundBox.SetBool("bool_BassA_", true);
            Debug.Log("Bass A plays");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (BassA_trig)

            {
                _soundBox.Play(_bassA_Trigger, 0, 0.0f);
                gameObject.SetActive(false);
                //_stopTrigObj.SetActive(true);
            }
            if (KeysA1_trig)

            {
                _soundBox.Play(_keysA1_Trigger, 0, 0.0f);
                gameObject.SetActive(false);
                //_stopTrigObj.SetActive(true);
            }

            else if (Idle_trig)              
            {
                _soundBox.Play(_idle_Trigger, 0, 0.0f);
                //_startTrigObj.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
    public void FireSongs()
    {
        if (_musicTrig)
        {
            if (BassA_trig)

            {
                _soundBox.Play(_bassA_Trigger, 0, 0.0f);
                //_stopTrigObj.SetActive(true);
                Debug.Log("Bass A plays");
            }
            if (KeysA1_trig)

            {
                _soundBox.Play(_keysA1_Trigger, 0, 0.0f);
                //_stopTrigObj.SetActive(true);
            }

            else if (Idle_trig)
            {
                _soundBox.Play(_idle_Trigger, 0, 0.0f);
                //_startTrigObj.SetActive(true);
            }
        }
    }
}



