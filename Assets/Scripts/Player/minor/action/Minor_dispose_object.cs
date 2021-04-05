using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minor_dispose_object : MonoBehaviour
{
    public GameObject square;

    bool isInstantiate = false;
    private GameObject newInstantiate = null;


    public GameObject bar;
    void Update()
    {
        Vector3 position = transform.position;

        instanceKeyDown(new Vector3(position.x, position.y + 2), KeyCode.UpArrow);
        instanceKeyDown(new Vector3(position.x - 2, position.y), KeyCode.LeftArrow);
        instanceKeyDown(new Vector3(position.x + 2, position.y), KeyCode.RightArrow);
        instanceKeyDown(new Vector3(position.x, position.y - 2), KeyCode.DownArrow);
    }
    private void instanceKeyDown(Vector3 newPosition, KeyCode keyVerification)
    {
        if (Input.GetKey(keyVerification) && !isInstantiate)
        {
            newInstantiate = Instantiate(square, newPosition, Quaternion.identity);
            isInstantiate = true;
        }
        else if (Input.GetKeyUp(keyVerification) && isInstantiate)
        {
            Destroy(newInstantiate);
            isInstantiate = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightControl) && isInstantiate == true)
        {
            isInstantiate = false;
            newInstantiate = null;
        }

    }
}
