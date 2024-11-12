using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class WorldPosition : MonoBehaviour
{
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera camera)
    {
        screenPosition.z = Mathf.Abs(camera.transform.position.z);
        Vector3 worldPosition = Camera.ScreenToWorld(screenPosition);
        return worldPosition;
    }

    public static Vector3 MouseWorldPosition()
    {

    }
}
