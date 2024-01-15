using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Properties/CharacterProperties")]
public class CharacterProperties: ScriptableObject
{
    #region Fields

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minStamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float minManeuverability;
    [SerializeField] private float maxManeuverability;

    #endregion

    #region Random

    public float RandomSpeed => (float)Math.Round(Random.Range(minSpeed, maxSpeed), 2);
    public float RandomStamina => (float)Math.Round(Random.Range(minStamina, maxStamina), 2);
    public float RandomManeuverability => (float)Math.Round(Random.Range(minManeuverability, maxManeuverability), 2);

    #endregion
}