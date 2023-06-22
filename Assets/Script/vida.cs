using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public int maxlife;
    public int currentlife;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localScale = new Vector3( currentlife * 100 / maxlife, 1, 1);
    }

   
}


