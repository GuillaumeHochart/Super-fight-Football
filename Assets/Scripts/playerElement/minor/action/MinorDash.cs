using exception;
using UnityEngine;

namespace playerElement.minor.action
{
    public class MinorDash : MonoBehaviour
    {
        public int distance;
        public int costOfAction = 5;
        public GameObject square;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Dash action");
                Minor minor = GetComponent<Minor>();

                Vector2 minorPosition = minor.transform.position;
                
                if(!minor.CheckPossibleAction(costOfAction)) return;
                ChangeMinorPosition(minor);
                AddBlockToPosition(minorPosition);
            }
            
        }

        private void ChangeMinorPosition(Minor minor)
        {
            if (minor == null) throw new BussinesException("minor is null");

            if (Input.GetKey(KeyCode.Z)) minor.transform.position = 
                    new Vector2(minor.transform.position.x,minor.transform.position.y+distance);
            
            if (Input.GetKey(KeyCode.Q)) minor.transform.position = 
                new Vector2(minor.transform.position.x-distance,minor.transform.position.y);
            
            if (Input.GetKey(KeyCode.D)) minor.transform.position = 
                new Vector2(minor.transform.position.x+distance,minor.transform.position.y);
            
            if (Input.GetKey(KeyCode.S)) minor.transform.position = 
                new Vector2(minor.transform.position.x,minor.transform.position.y-distance);
        }

        private void AddBlockToPosition(Vector3 squarePosition)
        {
            if (squarePosition == null) throw new BussinesException("squarePosition is null");
            square.GetComponent<BoxCollider2D>().isTrigger = false;
            square.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Instantiate(square, squarePosition, Quaternion.identity);
            
        }
    }
}