using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="TrailConfig", menuName ="Guns/Gun Trail Configuration", order = 4)]
public class TrailConfiguration : ScriptableObject
{
    public Material tracerMaterial; // Bullet tracer material
    public AnimationCurve widthCurve;
    public float duration = 0.5f;
    public float minVertexDistance = 0.1f;
    public Gradient color;

    public float missDistance = 100f;
    public float simulationSpeed = 100f;
}
