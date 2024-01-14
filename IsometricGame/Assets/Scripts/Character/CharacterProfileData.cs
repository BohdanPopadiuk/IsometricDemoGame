using UnityEngine;

[CreateAssetMenu(menuName = "Properties/CharacterProfile")]
public class CharacterProfileData: ScriptableObject
{
    [SerializeField] private string[] names;
    [SerializeField] private Sprite[] avatars;

    public CharacterProfile GenerateRandomProfile()
    {
        string randomName = names[Random.Range(0, names.Length)];
        Sprite randomAvatar = avatars[Random.Range(0, avatars.Length)];

        return new CharacterProfile(randomName, randomAvatar);
    }
}