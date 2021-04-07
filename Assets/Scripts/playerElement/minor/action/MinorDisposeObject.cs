using System;
using System.Collections;
using exception;
using JetBrains.Annotations;
using playerElement.util;
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

        public int forceInvokRock = 10;
        
        private void Update()
        {
            Vector2 position = transform.position;
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var objectivePosition = VectorUtils.LerpByDistance(position, mouse, lerp);
            Debug.Log("LERP"+objectivePosition);

            InstanceKeyDown(GetGroundPosition(objectivePosition), mouse);
            TransformGameObjectPosition(objectivePosition);
            UpdateMinorState();
        }

        private void TransformGameObjectPosition(Vector2 objectivePosition)
        {
            Minor minor = GetComponent<Minor>();

            if (_isInstantiate)
            {
                Debug.Log("object"+_newInstantiate.transform.position);
                Debug.Log("objective"+objectivePosition);

            }
            
            if (!Input.GetMouseButton(1)) return;

            ChangeStateMinor(false);
            if (_newInstantiate == null) return;

            Vector2 vectorRef = Vector2.zero;

            if (_newInstantiate.transform.position.y > objectivePosition.y)
            {
                minor.StateMinor.isLaunchable = true;
            }

            if (!minor.StateMinor.isLaunchable)
            {
                _newInstantiate.transform.position =
                    new Vector2(_newInstantiate.transform.position.x,
                        _newInstantiate.transform.position.y + forceInvokRock * Time.deltaTime);
            }
            else
            {
                _newInstantiate.transform.position = objectivePosition;
            }
        }

        private Vector2 GetGroundPosition(Vector2 objectivePosition)
        {
            var down = new Vector2(0, Math.Abs(objectivePosition.y * 100) * -1);
            Debug.DrawRay(objectivePosition, down, Color.red);
            var hit = Physics2D.Raycast(objectivePosition, down);

            return hit.point;
        }

        private void UpdateMinorState()
        {
            if (Input.GetMouseButtonUp(1))
            {
                ChangeStateMinor(true);
            }
        }

        private void InstanceKeyDown(Vector3 newPosition, Vector3 mousePosition)
        {
            if (mousePosition == null) throw new BussinesException("mouse position is null");

            if (Input.GetMouseButtonDown(1) && !_isInstantiate)
            {
                Minor minor = GetComponent<Minor>();
                square.GetComponent<BoxCollider2D>().isTrigger = true;
                square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                _newInstantiate = Instantiate(square, new Vector2(newPosition.x,newPosition.y -2), Quaternion.identity);
                _isInstantiate = true;
                minor.StateMinor.isLaunchable = false;
            }
            else if (Input.GetMouseButtonUp(1) && _isInstantiate)
            {
                Minor minor = GetComponent<Minor>();
                Destroy(_newInstantiate);
                _isInstantiate = false;
                minor.StateMinor.isLaunchable = false;
            }
            else if (Input.GetMouseButtonUp(0) && _isInstantiate == true)
            {
                Destroy(_newInstantiate);
                square.GetComponent<BoxCollider2D>().isTrigger = false;
                square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GameObject instantiate = Instantiate(square, newPosition, Quaternion.identity);

                _isInstantiate = false;
                _newInstantiate = null;
                LaunchObject(instantiate, mousePosition);
            }
        }

        private void ChangeStateMinor(bool state)
        {
            Minor minor = GetComponent<Minor>();

            minor.StateMinor.IsDisposeObject = state;
        }

        private void LaunchObject(GameObject objectSmash, [NotNull] Vector3 mousePosition)
        {
            var rObject = objectSmash.GetComponent<Rigidbody2D>();
            if (rObject == null) throw new BussinesException("Object has not rigidbody");

            Vector2 originalPosition = rObject.transform.position;

            Vector2 targetPosition = VectorUtils.LerpByDistance(originalPosition, mousePosition, forceShoot);
            rObject.AddForce(targetPosition - (Vector2) transform.position, ForceMode2D.Impulse);
        }
    }
}