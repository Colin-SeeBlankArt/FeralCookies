using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] material;
    public Renderer rend;
        
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rend.sharedMaterial = material[1];

        }
    }

}
