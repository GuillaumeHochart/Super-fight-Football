using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Minor_dispose_object : MonoBehaviour
{
    bool isInstantiate = false;
    private GameObject newInstantiate = null;

    public GameObject square;

    public float lerp = 2;
    void Update()
    {
        Vector2 position = transform.position;


        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 newPosition = LerpByDistance(position, mouse, lerp);


        instanceKeyDown(newPosition);


        // transform
        if (Input.GetMouseButton(1))
        {
            changeStateMinor(false);
            if (newInstantiate != null)
            {
                newInstantiate.transform.position = newPosition;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            changeStateMinor(true);
        }


    }
    public Vector2 LerpByDistance(Vector2 playerPosition, Vector2 mousePosition, float x)
    {
        Vector2 BA = mousePosition - playerPosition;
        Vector2 BANormalize = Vector3.Normalize(BA);
        Vector2 intensité = x * BANormalize;

        Vector2 P = intensité + playerPosition;
        return P;
    }

    private void instanceKeyDown(Vector3 newPosition)
    {
        if (Input.GetMouseButtonDown(1) && !isInstantiate)
        {
            square.GetComponent<BoxCollider2D>().isTrigger = true;
            square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            newInstantiate = Instantiate(square, newPosition, Quaternion.identity);
            isInstantiate = true;
        }
        else if (Input.GetMouseButtonUp(1) && isInstantiate)
        {
            Destroy(newInstantiate);
            isInstantiate = false;
        }
        else if (Input.GetMouseButtonUp(0) && isInstantiate == true)
        {
            Destroy(newInstantiate);
            square.GetComponent<BoxCollider2D>().isTrigger = false;
            square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            GameObject instantiate=Instantiate(square, newPosition, Quaternion.identity);

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
