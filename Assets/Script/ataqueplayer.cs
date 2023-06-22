using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueplayer : MonoBehaviour
{
    private bool atacando;

    public Transform ataquepoint;
    public float ataquerangr = 0.5f;
    public LayerMask enemylayer;

    private void Update()
    {
        if(atacando == true) 
        {
            ataca();
        }

        void ataca()
        {
            Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(ataquepoint.position, ataquerangr, enemylayer);

            foreach (Collider2D enemy in hitEnimies)
            {
                enemy.GetComponent<inimigo2vida>().DanoNoInimigo(20);
            }
        }

        
    }
private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ataquepoint.position, ataquerangr);
    }
}
