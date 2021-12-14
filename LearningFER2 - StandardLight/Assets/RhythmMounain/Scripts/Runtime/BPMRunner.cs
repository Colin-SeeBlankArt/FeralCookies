using System;
using Dreamteck.Forever;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class BPMRunner : Runner
{
    protected override void Update()
    {
        base.Update();
    }

    [SerializeField] private float m_bpm = 120f;

    [SerializeField] private int m_beatsPerMeasure = 4;

    private EVENT_CALLBACK m_callback;
    private EventDescription m_nestedEvent;

    private void Start()
    {
        RuntimeManager.StudioSystem.getEvent("event:/ZacksEvent/Nested Event", out m_nestedEvent);
        m_callback = new EVENT_CALLBACK(Callback);
        m_nestedEvent.setCallback(m_callback);
    }

    private void OnGUI()
    {
        RuntimeManager.StudioSystem.getEvent("event:/ZacksEvent", out var desc);
        
        desc.getInstanceList(out var instanceList);
        desc.getLength(out var len);
        var totalBeats = TimeSpan.FromMilliseconds(len).TotalMinutes * m_bpm;
        for (var i = 0; i < instanceList.Length; i++)
        {
            instanceList[i].getTimelinePosition(out var pos);
            var elapsedMinutes = TimeSpan.FromMilliseconds(pos).TotalMinutes;
            var elapsedBeats = elapsedMinutes * m_bpm;

            var posInSong = pos / (float)len;
            GUILayout.Label($"Pos: {posInSong:0.00} beat: {elapsedBeats:0} total: {totalBeats:0} test: {Math.Floor(elapsedBeats / (double)m_beatsPerMeasure):0}");
        }
    }

    private RESULT Callback(EVENT_CALLBACK_TYPE type, IntPtr _event, IntPtr parameters)
    {
        return RESULT.OK;
    }
}