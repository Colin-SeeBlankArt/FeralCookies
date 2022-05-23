using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBunny : MonoBehaviour
{
    public GameObject Bunny;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bunny);
        }
    }
}
