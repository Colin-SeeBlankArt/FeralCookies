using System;
using System.Collections.Generic;
using System.Reflection;
using Dreamteck.Forever;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private Animator ShipAnim = null;

    public  GameObject _speedometer;

    public static PlayerCtrl instance;

    private ParticleSystem.Particle[] m_particleBuffer = Array.Empty<ParticleSystem.Particle>();
    private ParticleSystem[] m_particleSystems = Array.Empty<ParticleSystem>();

    private Vector3[] m_positionBuffer = Array.Empty<Vector3>();
    private TrailRenderer[] m_trailRenderers = Array.Empty<TrailRenderer>();

    private LaneRunner runner;

    //taken from DreamTeck.Forever.MathPlayer.cs
    public static int _speedBoostCheck = 0;
    float boost = 2f;
    
    float speed;
    float startSpeed = 0;

    //test to find this out. May need to be Public in GameManager
    float minSpeed;
    float maxSpeed = 15f; 

    // Zack: Had to use reflection since unity tried to hide this information. Not great!
    private readonly FieldInfo trailsField = typeof(ParticleSystem.Trails).GetField("positions", BindingFlags.Instance | BindingFlags.NonPublic);

    //private Animator _turnAnim;
    bool _turnL, _turnR;  // using ths to keep the ship leaning into a turn
    private AudioManager soundBite;
    public static int _redbrick=0; //reduce speed when hitting a bunny or red brick

    //timer for clamping speed changes
    private float elapsed;
    private float timerSpeed = 0.2f;

void Start()
    {
        //soundBite.Play("EngineNoise");

        //maxSpeed = GameManger._maxSpeed;  // build/test this
    }
    void Awake()
    {
        m_trailRenderers = GetComponentsInChildren<TrailRenderer>(true);
        m_particleSystems = GetComponentsInChildren<ParticleSystem>(true);

        runner = GetComponent<LaneRunner>();
        startSpeed = speed = runner.followSpeed;
        instance = this;

        //_turnAnim = GetComponent<Animator>();

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
            ScoringSystem._penalty++;
            Debug.Log("BunnyRed Speed Minus");
        }
        if (collider.CompareTag("Ally"))
        {
            soundBite.Play("Ally");
        }

        if (collider.CompareTag("BlockL"))
        {
            runner.lane++;
            ShipAnim.SetBool("Right_trig", true);
            soundBite.Play("Bump");
        }
        if (collider.CompareTag("BlockR"))
        {
            runner.lane--;
            ShipAnim.SetBool("Left_trig", true);
            soundBite.Play("Bump");
        }
    }

    void Update()
    {
        if(speed >= maxSpeed)
        {
            CollectBrick._canBoost = false;
            SetSpeed(speed=
                maxSpeed);            
        }
        else {CollectBrick._canBoost = true;}

        _speedometer.GetComponent<Text>().text ="Speed: " + speed.ToString() + " mps"; 

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            runner.followSpeed++; 
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W))
        {
            runner.followSpeed--;
        }

    }
    public void Left()
    {
        runner.lane--;
        ShipAnim.SetBool("Left_trig", true);
    }
    public void Right()
    {
        runner.lane++;
        ShipAnim.SetBool("Right_trig", true);
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
            //EndScreen.Open();
        }
    }
    public void Spedometer()
    {
        Debug.Log("speed boost " + runner.followSpeed);
    }
    public void SlowPlayer()
    {
        SetSpeed(GetSpeed() - boost);
        Debug.Log("speed slow " + runner.followSpeed);
        //runner.followSpeed = speed;
    }
    public void ElapseTimer()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timerSpeed)
        {
            elapsed = 0f;
            Destroy(gameObject);
        }
        
    }
}
