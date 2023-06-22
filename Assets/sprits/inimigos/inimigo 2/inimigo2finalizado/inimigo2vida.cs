using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2vida : MonoBehaviour
{

    private int vidaAtual= 10;

    public void DanoNoInimigo(int dano)
    {
        vidaAtual -= dano;

        if(vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
