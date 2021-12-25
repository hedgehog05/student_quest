using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP;
    public int MaxHp;
    // Start is called before the first frame update
    public void TakeDamage(int Dmg)
    {
        HP -= Dmg;

        if (HP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("Ded.");
    }
}
