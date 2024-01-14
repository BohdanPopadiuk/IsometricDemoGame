using System;
using System.Collections.Generic;
using Ui;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static Action<int> SelectCharacter;
    
    private List<CharacterController> _characters = new List<CharacterController>();
    private int _currentCharacter;
    void Awake()
    {
        CharacterController.CharacterCreated += AddNewCharacter;
        SelectCharacter += SetCurrentCharacter;
    }

    private void OnDestroy()
    {
        CharacterController.CharacterCreated -= AddNewCharacter;
        SelectCharacter -= SetCurrentCharacter;
    }

    private void AddNewCharacter(CharacterController character)
    {
        _characters.Add(character);
    }

    private void SetCurrentCharacter(int index)
    {
        _currentCharacter = index;
    }
}
