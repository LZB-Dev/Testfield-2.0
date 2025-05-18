using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Trail Config", menuName = "Guns/Gun Trail Config", order = 4)]
public class TrailConfig_ScriptableObject : ScriptableObject //bap
{
    public Material Material;
    public Gradient Color;
    public AnimationCurve WidthCurve;
    public float Duration = 0.5f;
    public float MinVertexDistance = 0.1f;

    public float MissDistance = 100f;
    public float SimulationSpeed = 100;
}
