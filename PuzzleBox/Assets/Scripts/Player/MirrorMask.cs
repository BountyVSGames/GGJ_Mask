using UnityEngine;

public class MirrorMask : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;

    // Update is called once per frame
    void Update()
    {
        Quaternion quat = objectToFollow.transform.localRotation;
        Quaternion newRotQuat = new Quaternion(quat.x, quat.y, quat.z * -1.0f, quat.w * -1.0f);

        if(transform.localRotation != newRotQuat)
        {
            transform.localRotation = newRotQuat;
        }
    }
}
