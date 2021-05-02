using System;
using System.Collections;
using exception;
using JetBrains.Annotations;
using Mirror;
using playerElement.util;
using UnityEngine;

namespace playerElement.minor.action
{
    public class MinorDisposeObject : MonoBehaviour
    {
        private bool _isInstantiate = false;
        private GameObject _newInstantiate = null;

        /**gameObject**/
        public GameObject square;

        /**input variable**/
        public float lerp = 2;
        public int forceShoot = 250;
        public int forceInvokRock = 10;
        public int costOfAction = 5;
        
        private void Update()
        {
            Minor minor = GetComponent<Minor>();

            if (minor.isLocalPlayer)
            {
                Vector2 position = transform.position;
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var objectivePosition = VectorUtils.LerpByDistance(position, mouse, lerp);

                if (minor == null) throw new BussinesException("minor is null");

                InstantiateBlock(minor, VectorUtils.GetGroundPosition(objectivePosition), mouse);
                TransformBlockPosition(minor, objectivePosition);
                UpdateMinorState();
            }
        }

        private void TransformBlockPosition([NotNull]Minor minor,Vector2 objectivePosition)
        {

            if (!Input.GetMouseButton(1)) return;

            ChangeStateMinor(false);
            if (_newInstantiate == null) return;
            
            if (_newInstantiate.transform.position.y > objectivePosition.y) minor.stateMinor.IsLaunchable = true;
 

            if (!minor.stateMinor.IsLaunchable)
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
        
        private void UpdateMinorState()
        {
            if (Input.GetMouseButtonUp(1))
            {
                ChangeStateMinor(true);
            }
        }

        private void InstantiateBlock([NotNull]Minor minor,Vector3 newPosition, Vector3 mousePosition)
        {
            if (mousePosition == null) throw new BussinesException("mouse position is null");

            if (Input.GetMouseButtonDown(1) && !_isInstantiate)
            {
                square.GetComponent<BoxCollider2D>().isTrigger = true;
                square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                _newInstantiate = Instantiate(square, new Vector2(newPosition.x,newPosition.y -2), Quaternion.identity);
                _isInstantiate = true;
                minor.stateMinor.IsLaunchable = false;
            }
            else if (Input.GetMouseButtonUp(1) && _isInstantiate)
            {
                Destroy(_newInstantiate);
                _isInstantiate = false;
                minor.stateMinor.IsLaunchable = false;
            }
            else if (Input.GetMouseButtonUp(0) && _isInstantiate == true)
            {
                if (!minor.CheckPossibleAction(costOfAction)) return;
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

            minor.stateMinor.IsDisposeObject = state;
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