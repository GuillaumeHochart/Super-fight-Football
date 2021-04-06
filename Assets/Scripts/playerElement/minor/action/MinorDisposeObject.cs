using exception;
using JetBrains.Annotations;
using UnityEngine;

namespace playerElement.minor.action
{
    public class MinorDisposeObject : MonoBehaviour
    {
        private bool _isInstantiate = false;
        private GameObject _newInstantiate = null;

        public GameObject square;

        public float lerp = 2;

        public int forceShoot = 250;
        
        private void Update()
        {
            Vector2 position = transform.position;
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            Vector2 newPosition = LerpByDistance(position, mouse, lerp);


            InstanceKeyDown(newPosition,mouse);


            // transform
            if (Input.GetMouseButton(1))
            {
                Debug.Log(" MOUSE x : "+mouse.x+" y : "+mouse.y);
                Debug.Log(" OBJECT x : "+newPosition.x+" y : "+newPosition.y);

                ChangeStateMinor(false);
                if (_newInstantiate != null)
                {
                    _newInstantiate.transform.position = newPosition;
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                ChangeStateMinor(true);
            }


        }

        private Vector2 LerpByDistance(Vector2 playerPosition, Vector2 mousePosition, float x)
        {
            Vector2 ba = mousePosition - playerPosition;
            Vector2 baNormalize = Vector3.Normalize(ba);
            Vector2 force = x * baNormalize;

            Vector2 p = force + playerPosition;
            return p;
        }

        private void InstanceKeyDown(Vector3 newPosition,Vector3 mousePosition)
        {
            if (mousePosition == null) throw new BussinesException("mouse position is null");

            if (Input.GetMouseButtonDown(1) && !_isInstantiate)
            {
                square.GetComponent<BoxCollider2D>().isTrigger = true;
                square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                _newInstantiate = Instantiate(square, newPosition, Quaternion.identity);
                _isInstantiate = true;
            }
            else if (Input.GetMouseButtonUp(1) && _isInstantiate)
            {
                Destroy(_newInstantiate);
                _isInstantiate = false;
            }
            else if (Input.GetMouseButtonUp(0) && _isInstantiate == true)
            {
                Destroy(_newInstantiate);
                square.GetComponent<BoxCollider2D>().isTrigger = false;
                square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GameObject instantiate=Instantiate(square, newPosition, Quaternion.identity);

                _isInstantiate = false;
                _newInstantiate = null;
                Smash(instantiate,mousePosition);

            }

        }
        private void ChangeStateMinor(bool state)
        {
            Minor minor = GetComponent<Minor>();

            minor.StateMinor.IsDisposeObject = state;
        }

        private void Smash(GameObject objectSmash,[NotNull] Vector3 mousePosition)
        {


            Vector3 velocityRef = Vector3.zero;

            var rObject = objectSmash.GetComponent<Rigidbody2D>();
            if (rObject == null) throw new BussinesException("Object has not rigidbody");
          
            Vector2 originalPosition = rObject.transform.position;
            
            float horizontalMovement = mousePosition.x * forceShoot * Time.deltaTime;
            float verticalMovement = mousePosition.y * forceShoot * Time.deltaTime;

            Vector2 targetPosition = LerpByDistance(originalPosition, mousePosition, forceShoot);
            Debug.Log(" Target Position : x "+targetPosition.x+" y : "+targetPosition.y);
            objectSmash.transform.position = Vector3.SmoothDamp(originalPosition, targetPosition,ref velocityRef,.05f);

        }
    }
}
