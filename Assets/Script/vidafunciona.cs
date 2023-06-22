using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidafunciona : MonoBehaviour
{

    public float vida;
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        vida -= 1;
        


        if (vida <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("gameover");
        }

        Destroy(collision.gameObject);

    }
   
    

}

