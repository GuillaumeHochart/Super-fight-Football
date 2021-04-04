using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public GameObject player;

    public float timeOffset;
    public Vector3 postOffset;

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + postOffset, ref velocity, timeOffset);
    }
}
