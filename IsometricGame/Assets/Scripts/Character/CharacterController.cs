using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    public static Action<CharacterController> CharacterCreated;
    
    [SerializeField] private CharacterProperties properties;
    [SerializeField] private CharacterProfileData profileData;
    
    public List<Vector3> Path { get; private set; }
    private float _speed;
    private float _stamina;
    private float _maneuverability;
    private CharacterProfile _profile;

    private void Start()
    {
        GenerateCharacter();
    }

    private void GenerateCharacter()
    {
        _speed = properties.RandomSpeed;
        _stamina = properties.RandomStamina;
        _maneuverability = properties.RandomManeuverability;
        _profile = profileData.GenerateRandomProfile();
        
        CharacterCreated?.Invoke(this);

        Debug.Log("New generated character: " + GetCharacterInfo().Replace("<br>", " | "));
    }
    

    private void Move(List<Vector3> path)
    {
        Path = path;
        
    }
    
    private void Follow(CharacterController target)
    {
        
    }

    public string GetCharacterInfo()
    {
        return $"<b>{properties.name}</b> - {_profile.GetName}<br>" +
               $"speed: {_speed}<br>" +
               $"stamina: {_stamina}<br>" +
               $"maneuverability: {_maneuverability}";
    }
}
