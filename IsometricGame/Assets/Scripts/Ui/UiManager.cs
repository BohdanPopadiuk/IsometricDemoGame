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
            //create a button for each person and add a text description
            int characterIndex = characterButtonsParent.childCount;
            
            Button characterButton = Instantiate(characterButtonPrefab, characterButtonsParent);
            characterButton.onClick.AddListener(() => GameController.SelectCharacter?.Invoke(characterIndex));

            Image image = characterButton.GetComponent<Image>();
            image.sprite = character.Profile.GetAvatar;
            
            TextMeshProUGUI text = characterButton.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            text.SetText(character.GetCharacterInfo());
        }
    }
}
