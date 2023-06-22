using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2 : MonoBehaviour
{
    public float speedtiro;
    public float tempo;
    float time;
    private void Update()
    {
        time += Time.deltaTime;
        transform.position += Vector3.left * speedtiro * Time.deltaTime;

        if(time >= tempo)
        {
            Destroy(gameObject);
        }

    }


}
