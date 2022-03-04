using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public  Transform target;
    public float SpeedRotation;
    [Header("Zoom")]
    public Transform Position1;
    public Transform Position2;
    public float ZoomSpeed;
    public float Distance = 0.5f;
    public Transform Camera;
    [Header ("Oclusion")]
    public Transform NoneCollision;
    public Transform Collision;
    public float CameraSpeed;
    public LayerMask OclusionStates;
    public Transform AimTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        transform.LookAt(target);
        Vector3 rotacion = transform.eulerAngles;
        rotacion.y += Input.GetAxis("Mouse X") * SpeedRotation * Time.deltaTime;
        rotacion.x -= Input.GetAxis("Mouse Y") * SpeedRotation * Time.deltaTime;
        rotacion.x = Mathf.Clamp(rotacion.x, 0 ,70 );
        transform.eulerAngles = rotacion;

        //calculo de la distancia de la camara

        Distance += ZoomSpeed * Input.mouseScrollDelta.y * Time.deltaTime;
        Distance = Mathf.Clamp(Distance, 0, 1);
        LocationZoomCamera();
        Camera.localPosition = Vector3.Lerp(Camera.localPosition,Collision.localPosition,CameraSpeed*Time.deltaTime);
    }
    public void OnDrawGizmos()
    {
        LocationZoomCamera();
        CollisionDetector();
        Gizmos.DrawLine(Position1.position, Collision.position);
    }
    public void CollisionDetector()
    {
        Ray DETECTOR = new Ray(Position1.position, (Position2.position - Position1.position) );
        RaycastHit hit;
        float DistanceRay = (Position1.position - NoneCollision.position).magnitude + 0.1f;

        if (Physics.Raycast(DETECTOR,out hit , DistanceRay,OclusionStates))
        {
            Collision.position = hit.point;
        }
        else
        {
            Collision.position = NoneCollision.position;
        }
    }
    public void LocationZoomCamera()
    {
        NoneCollision.localPosition = Position1.localPosition + (Position2.localPosition - Position1.localPosition) * Distance;
    }
}
