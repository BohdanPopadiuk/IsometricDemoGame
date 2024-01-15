using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class CharacterCanvasUi : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private GameObject mainCharacterIndicator;
        [SerializeField] private GameObject lowStaminaIndicator;
        [SerializeField] private Image staminaBarImage;

        private void Start()
        {
            //disconnect the indicator from the character to ignore its rotation
            transform.parent = null;
        }

        private void Update()
        {
            lowStaminaIndicator.SetActive(characterController.LowStamina);
            mainCharacterIndicator.SetActive(characterController.SelectedCharacter);
            
            //just a stamina indicator :)
            staminaBarImage.fillAmount = characterController.Stamina / characterController.FullStamina;
            
            //setting the color of the indicator (green - full stamina, red - low stamina)
            float colorGreen = (255f / 100f * (staminaBarImage.fillAmount * 100)) / 255f;
            float colorRed = (255f / 100f * (100f - staminaBarImage.fillAmount * 100)) / 255f;
            staminaBarImage.color = new Color(colorRed, colorGreen, 0f, 255f);
            
            //move the indicators by character
            Vector3 characterPos = characterController.transform.position;
            transform.position = new Vector3(characterPos.x, transform.position.y, characterPos.z);
        }
    }
}