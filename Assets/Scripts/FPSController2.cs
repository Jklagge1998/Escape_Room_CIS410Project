using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController2 : PortalTraveller {

    public float yaw;
    public float pitch;
    float smoothYaw;
    float smoothPitch;
    Vector3 velocity;
    new Rigidbody rigidbody;
    public PlayerMovement playermovement;
    


    void Start () { }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot) {
        Debug.Log("TELEPORT");
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        float delta = Mathf.DeltaAngle (smoothYaw, eulerRot.y);
        
        yaw += delta;
        smoothYaw += delta;
        transform.eulerAngles = Vector3.up * smoothYaw;
        velocity = toPortal.TransformVector (fromPortal.InverseTransformVector (velocity));
        Physics.SyncTransforms ();
        //playermovement.inportal = true;

    }

}