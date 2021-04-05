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

    
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        if (mouse.x > position.x)
        {
            instanceKeyDown(new Vector3(position.x + 2, mouse.y), KeyCode.RightArrow);
        }
        if (mouse.x < position.x)
        {
            instanceKeyDown(new Vector3(position.x - 2, mouse.y), KeyCode.LeftArrow);
        }

        // transform
        if (Input.GetMouseButton(1)) 
        {
            changeStateMinor(false);
            if (mouse.x < position.x)
            {
                newInstantiate.transform.position = new Vector3(position.x - 2, mouse.y);
            }
            if (mouse.x > position.x)
            {
                newInstantiate.transform.position = new Vector3(position.x + 2, mouse.y);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            changeStateMinor(true);
        }


    }
    private void instanceKeyDown(Vector3 newPosition, KeyCode keyVerification)
    {
        if ((Input.GetKey(keyVerification) || Input.GetMouseButtonDown(1)) && !isInstantiate)
        {
            square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            newInstantiate = Instantiate(square, newPosition, Quaternion.identity);
            isInstantiate = true;
        }
        else if ((Input.GetKeyUp(keyVerification) || Input.GetMouseButtonUp(1)) && isInstantiate)
        {
            Destroy(newInstantiate);
            isInstantiate = false;
        }
        else if ((Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonUp(0)) && isInstantiate == true)
        {
            Destroy(newInstantiate);
            square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            newInstantiate = Instantiate(square, newPosition, Quaternion.identity);

            isInstantiate = false;
            newInstantiate = null;
        }

    }
    private void changeStateMinor(bool state)
    {
        Minor minor = GetComponent<Minor>();

        minor.State_minor.IsDisposeObject = state; 
    }
}
