using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungsi_rotasi : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5*10*Time.deltaTime, 0);
    }
}
