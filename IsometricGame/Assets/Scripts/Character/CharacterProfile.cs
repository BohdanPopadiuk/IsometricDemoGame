using System;
using UnityEngine;

[Serializable]
public struct CharacterProfile
{
    public CharacterProfile(string name, Sprite avatar)
    {
        _name = name;
        _avatar = avatar;
    }
    
    private string _name;
    private Sprite _avatar;

    public string GetName => _name;
    public Sprite GetAvatar => _avatar;
}