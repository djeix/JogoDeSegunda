using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class trocacena : MonoBehaviour
{
    public void LoadScene(string nomecena)
    {
        SceneManager.LoadScene(nomecena);
    }

}
