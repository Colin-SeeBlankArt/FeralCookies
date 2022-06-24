using System;
using System.Collections.Generic;
using System.Reflection;
using Dreamteck.Forever;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerCtrl : MonoBehaviour
{
   
    public static PlayerCtrl instance;
     
    private ParticleSystem.Particle[] m_particleBuffer = Array.Empty<ParticleSystem.Particle>();
    private ParticleSystem[] m_particleSystems = Array.Empty<ParticleSystem>();

    private Vector3[] m_positionBuffer = Array.Empty<Vector3>();

    private TrailRenderer[] m_trailRenderers = Array.Empty<TrailRenderer>();

    private LaneRunner runner;

    //bool canBoost = true;
    private float speed;
    private float startSpeed;

    // Zack: Had to use reflection since unity tried to hide this information. Not great!
    private readonly FieldInfo trailsField = typeof(ParticleSystem.Trails).GetField("positions", BindingFlags.Instance | BindingFlags.NonPublic);

    private Animator _turnAnim;
    bool _turnL, _turnR;  // using ths to keep the ship leaning into a turn
    private AudioManager soundBite;


    void Start()
    {
        soundBite.Play("EngineNoise");
    }
    void Awake()
    {
        m_trailRenderers = GetComponentsInChildren<TrailRenderer>(true);
        m_particleSystems = GetComponentsInChildren<ParticleSystem>(true);

        runner = GetComponent<LaneRunner>();
        startSpeed = speed = runner.followSpeed;
        instance = this;

        _turnAnim = GetComponent<Animator>();

        soundBite = FindObjectOfType<AudioManager>();

    }

    private void FloatingOriginOnonOriginOffset(Vector3 delta)
    {
        foreach (var trailRenderer in m_trailRenderers)
        {
            if (trailRenderer.positionCount > m_positionBuffer.Length)
            {
                Array.Resize(ref m_positionBuffer, trailRenderer.positionCount);
            }

            // Zack: Update trail renderer offsets
            var storedCount = trailRenderer.GetPositions(m_positionBuffer);
            for (var i = 0; i < storedCount; i++)
            {
                var storedPosition = m_positionBuffer[i];
                m_positionBuffer[i] = storedPosition - delta;
            }

            trailRenderer.SetPositions(m_positionBuffer);
        }

        foreach (var currentParticleSystem in m_particleSystems)
        {
            if (currentParticleSystem.particleCount > m_particleBuffer.Length)
            {
                Array.Resize(ref m_particleBuffer, currentParticleSystem.particleCount);
            }

            // Zack: Update particle offsets
            var storedCount = currentParticleSystem.GetParticles(m_particleBuffer);
            for (var i = 0; i < storedCount; i++)
            {
                var storedPosition = m_particleBuffer[i].position;
                m_particleBuffer[i].position = storedPosition - delta;
            }

            currentParticleSystem.SetParticles(m_particleBuffer);

            // Zack: Update particle system trail offsets
            var trails = currentParticleSystem.GetTrails();
            var positions = trailsField.GetValue(trails) as List<Vector4>;
            if (positions != null)
            {
                for (var i = 0; i < positions.Count; i++)
                {
                    positions[i] -= (Vector4)delta;
                }

                trailsField.SetValue(trails, positions);
            }

            currentParticleSystem.SetTrails(trails);
        }
    }

    private void OnDisable()
    {
        FloatingOrigin.onOriginOffset -= FloatingOriginOnonOriginOffset;
    }

    private void OnEnable()
    {
        FloatingOrigin.onOriginOffset += FloatingOriginOnonOriginOffset;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            soundBite.Play("BunnyPing");
        }
        if (collider.CompareTag("Brick"))
        {
            soundBite.Play("BrickPing");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            runner.lane--;
            _turnAnim.SetBool("Left_trig", true);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            runner.lane++;
            _turnAnim.SetBool("Right_trig", true);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //if  boost count == ?? && boost = false
                //On 2 Sec Timer:
                    // boost; (SetSpeed = GetSpeed+BoostSpeed (??))
                    //else boost == false
        }

    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        runner.followSpeed = speed;
        if (speed == 0f)
        {
            EndScreen.Open();
        }
    }
}