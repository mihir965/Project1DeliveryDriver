using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //The Camera's position should be the same as that of the car or Rath.

    [SerializeField] GameObject playerToFollow;

    void LateUpdate()
    {
        transform.position = playerToFollow.transform.position - new Vector3(0, 0, 10);
    }
}
