using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player_Movment Player_Movment;

    public static PlayerManager Instance { get; private set; } //static singleton

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }

        Player_Movment = FindObjectOfType<Player_Movment>();
    }

}
