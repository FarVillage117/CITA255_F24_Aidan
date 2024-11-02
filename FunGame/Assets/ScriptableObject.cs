using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
    (menuName = "Scriptable Object/New Location", fileName = "Location", order = 0)]
public class ScriptableObject : MonoBehaviour
{
    public string locationName;
    [TextArea(3, 5)] public string locationDesc;
}
