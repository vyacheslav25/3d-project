using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraConfig : ScriptableObject
{
    public float turnSmooth;
    public float speed;
    public float yRot;
    public float xRot;
    public float minAngle;
    public float maxAngle;
    public float normalX;
    public float normalY;
    public float normalZ;
    public float aimZ;
    public float aimX;
	
}
