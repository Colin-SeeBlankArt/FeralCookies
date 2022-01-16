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

    [SerializeField] private int m_offsetMilliseconds = 0;

    [SerializeField] private int m_beatStartOffset = 0;

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
        var totalMeasures = totalBeats / m_beatsPerMeasure;
        for (var i = 0; i < instanceList.Length; i++)
        {
            instanceList[i].getTimelinePosition(out var posMS);
            var offsetPosMS = posMS + m_offsetMilliseconds;
            var elapsedMinutes = TimeSpan.FromMilliseconds(offsetPosMS).TotalMinutes;
            var elapsedBeats = elapsedMinutes * m_bpm;

            var offsetElapsedBeats = elapsedBeats + m_beatStartOffset;
            var elapsedMeasures = (int)offsetElapsedBeats / m_beatsPerMeasure;
            var shortMeasure = (int)offsetElapsedBeats % m_beatsPerMeasure;

            var posInSong = (offsetPosMS / (float)len);
            GUILayout.Label($"%: {posInSong:0.00} beat: {elapsedBeats:0}/{totalBeats:0} Measure: {elapsedMeasures:0}/{totalMeasures:0} ({shortMeasure:0})");
        }
    }

    private RESULT Callback(EVENT_CALLBACK_TYPE type, IntPtr _event, IntPtr parameters)
    {
        return RESULT.OK;
    }
}