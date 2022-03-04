using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform Hands;
    public Animator PlayerAnimations;

    private void Start()
    {
        PlayerAnimations = GetComponent<Animator>();
    }

    void Update()
    {
        if (ControllerDialogos.INconversation)
            return;
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObjects>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObjects>().isPickable = false;
                PickedObject.transform.SetParent(Hands);
                PickedObject.transform.position = Hands.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObjects>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
            PlayerAnimations.SetBool("PickedObject", PickedObject );
        }
    }
}
