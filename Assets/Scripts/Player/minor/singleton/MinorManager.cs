using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorManager : MonoBehaviour
{
    public Minor minor;

    public static MinorManager Instance { get; private set; } //static singleton

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }

        minor = FindObjectOfType<Minor>();
    }
}
