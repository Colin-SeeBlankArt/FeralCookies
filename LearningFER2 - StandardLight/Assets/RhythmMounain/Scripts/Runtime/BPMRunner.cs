using System;
using Dreamteck.Forever;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class BPMRunner : MonoBehaviour
{
    private void Update()
    {
        CalculateEventProgress();
        
        if (LevelGenerator.instance == null || !LevelGenerator.instance.ready)
        {
            return;
        }

        var missing = m_elapsedMeasures - LevelGenerator.instance.segments.Count;
        if (missing > 0)
        {
            LevelGenerator.instance.QueueSegmentCreation(missing);
        }

        if (m_elapsedMeasures < LevelGenerator.instance.segments.Count)
        {
            var current = LevelGenerator.instance.segments[m_elapsedMeasures];
            if (current != m_lastSegment)
            {
                current.Enter();
                m_lastSegment = current;
            }
        }

        if (m_lastSegment != null)
        {
            var delta = m_beatInMeasure / (double)m_beatsPerMeasure;
            var newPos = m_lastSegment.EvaluatePosition(delta);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 10f);
        }
    }

    private LevelSegment m_lastSegment = null;
    
    private int m_beatInMeasure;

    [SerializeField] private int m_beatsPerMeasure = 4;

    [SerializeField] private int m_beatStartOffset;

    [SerializeField] private float m_bpm = 120f;

    private EVENT_CALLBACK m_callback;
    private double m_elapsedBeats;
    private int m_elapsedMeasures;
    private EventDescription m_nestedEvent;

    [SerializeField] private int m_offsetMilliseconds;
    private double m_posInSong;
    private double m_totalBeats;
    private double m_totalMeasures;

    private void CalculateEventProgress()
    {
        RuntimeManager.StudioSystem.getEvent("event:/ZacksEvent", out var desc);

        desc.getInstanceList(out var instanceList);
        desc.getLength(out var lenMS);
        m_totalBeats = TimeSpan.FromMilliseconds(lenMS).TotalMinutes * m_bpm;
        m_totalMeasures = m_totalBeats / m_beatsPerMeasure;
        for (var i = 0; i < instanceList.Length; i++)
        {
            instanceList[i].getTimelinePosition(out var posMS);
            var offsetPosMS = posMS + m_offsetMilliseconds;
            var elapsedMinutes = TimeSpan.FromMilliseconds(offsetPosMS).TotalMinutes;
            m_elapsedBeats = elapsedMinutes * m_bpm;

            var offsetElapsedBeats = m_elapsedBeats + m_beatStartOffset;
            m_elapsedMeasures = (int)offsetElapsedBeats / m_beatsPerMeasure;
            m_beatInMeasure = (int)offsetElapsedBeats % m_beatsPerMeasure;

            m_posInSong = offsetPosMS / (double)lenMS;
        }
    }

    private RESULT Callback(EVENT_CALLBACK_TYPE type, IntPtr _event, IntPtr parameters)
    {
        return RESULT.OK;
    }

    private void OnGUI()
    {
        GUILayout.Label($"%: {m_posInSong:0.00} Beat: {m_elapsedBeats:0}/{m_totalBeats:0} Measure: {m_elapsedMeasures:0}/{m_totalMeasures:0} ({m_beatInMeasure:0})");
    }

    private void Start()
    {
        RuntimeManager.StudioSystem.getEvent("event:/ZacksEvent/Nested Event", out m_nestedEvent);
        m_callback = Callback;
        m_nestedEvent.setCallback(m_callback);
    }
}