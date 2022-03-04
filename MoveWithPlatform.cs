using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    CharacterController Player;
    Vector3 GroundPosition;
    Vector3 lastGroundPosition;
    string GroundName;
    string lastGroundName;
    public Vector3 originOffset;
    public float DivisionFactor = 4.2f;
    //Quaternion actualRot;
    //Quaternion lastRot;
    //public Transform FLOORDETECTOR;
  
    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isGrounded)
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position + originOffset, Player.radius / DivisionFactor, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                GroundName = groundedIn.name;
                GroundPosition = groundedIn.transform.position;
                //actualRot = groundedIn.transform.rotation;

                if (GroundPosition != lastGroundPosition && GroundName == lastGroundName)
                {
                    this.transform.position += GroundPosition - lastGroundPosition;
                }
                //if (actualRot != lastRot && GroundName == lastGroundName)
                {
                   // var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    //this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }

                lastGroundName = GroundName;
                lastGroundPosition = GroundPosition;
            }




        }
        else if (!Player.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
            //lastRot = Quaternion.Euler(0, 0, 0);

        }

    }
    private void OnDrawGizmos()
    {
        Player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position + originOffset, Player.radius / DivisionFactor);
    }
}


