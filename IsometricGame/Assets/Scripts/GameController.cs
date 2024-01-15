using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static Action<int> SelectCharacter;

    private readonly List<CharacterController> _characters = new List<CharacterController>();
    private int _currentCharacter;
    void Awake()
    {
        CharacterController.CharacterCreated += AddNewCharacter;
        InputHandler.ClickedOnTheMap += MoveСharacters;
        SelectCharacter += SetCurrentCharacter;
    }

    private void OnDestroy()
    {
        CharacterController.CharacterCreated -= AddNewCharacter;
        InputHandler.ClickedOnTheMap -= MoveСharacters;
        SelectCharacter -= SetCurrentCharacter;
    }

    private void AddNewCharacter(CharacterController character)
    {
        // Select first generated character
        character.SetSelectStatus(_characters.Count == 0);
        //add the generated person to the list
        _characters.Add(character);
    }

    private void SetCurrentCharacter(int index)
    {
        //select the current person (depending on the button pressed)
        _currentCharacter = index;
        for (int i = 0; i < _characters.Count; i++)
        {
            _characters[i].SetSelectStatus(i == index);
        }
    }

    private void MoveСharacters(Vector3 targetPosition)
    {
        //for the main person, call move() method for the rest Follow()
        _characters[_currentCharacter].Move(targetPosition);

        Transform followTargetGroup = _characters[_currentCharacter].followGroup.GetChild(_characters.Count - 1);

        int followPoint = 0;

        for (int i = 0; i < _characters.Count; i++)
        {
            if(i == _currentCharacter) continue;
            _characters[i].Follow(followTargetGroup.GetChild(followPoint));
            followPoint++;
        }
    }
}
