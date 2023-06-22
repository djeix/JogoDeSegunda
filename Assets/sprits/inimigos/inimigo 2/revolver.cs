using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolver : MonoBehaviour
{
    public GameObject modeltiro;
    public float intervalotiro;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        
        if(time >= intervalotiro)
        {
            time -= intervalotiro;



            Instantiate(modeltiro, transform.position,  Quaternion.identity);
        }
    }
}
