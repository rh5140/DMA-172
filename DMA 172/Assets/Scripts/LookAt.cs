using UnityEngine;


public class LookAt : MonoBehaviour
{
    public Transform CameraToLookAt;


    void LateUpdate()
    {
        transform.LookAt(new Vector3(CameraToLookAt.position.x, transform.position.y, CameraToLookAt.position.z));
    }
}
