using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    public string name_scene;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(name_scene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
