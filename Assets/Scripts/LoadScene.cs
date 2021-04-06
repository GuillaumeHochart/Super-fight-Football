using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nameScene;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(nameScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
