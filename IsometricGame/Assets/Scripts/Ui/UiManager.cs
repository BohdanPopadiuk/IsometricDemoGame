using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private Transform characterButtonsParent;
        [SerializeField] private Button characterButtonPrefab;

        void Awake()
        {
            CharacterController.CharacterCreated += CreateCharacterButton;
        }

        private void OnDestroy()
        {
            CharacterController.CharacterCreated -= CreateCharacterButton;
        }

        private void CreateCharacterButton(CharacterController character)
        {
            int characterIndex = characterButtonsParent.childCount;
            Button characterButton = Instantiate(characterButtonPrefab, characterButtonsParent);
            characterButton.onClick.AddListener(() => GameController.SelectCharacter?.Invoke(characterIndex));
            characterButton.GetComponentInChildren<TextMeshProUGUI>().text = character.GetCharacterInfo();
        }
    }
}
