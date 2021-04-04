using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableElement : MonoBehaviour
{
    public int life = 1;

    public void Dammage(int dammage)
    {
        Debug.Log("Life actuel : "+life);
        Debug.Log("Dammage : "+dammage);
       
        life = life - dammage;
        if (CheckIsDeath())
        {
            Debug.Log(gameObject.name+" is death");

            gameObject.SetActive(false);
        }
    }
    private bool CheckIsDeath()
    {
        if(life <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
