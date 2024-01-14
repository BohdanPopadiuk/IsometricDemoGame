using System;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Properties/CharacterProperties")]
public class CharacterProperties: ScriptableObject
{
    public float minSpeed;
    public float maxSpeed;
    public float minStamina;
    public float maxStamina;
    public float minManeuverability;
    public float maxManeuverability;

    public float RandomSpeed => (float)Math.Round(Random.Range(minSpeed, maxSpeed), 2);
    public float RandomStamina => (float)Math.Round(Random.Range(minStamina, maxStamina), 2);
    public float RandomManeuverability => (float)Math.Round(Random.Range(minManeuverability, maxManeuverability), 2);
}