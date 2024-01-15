using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterController : MonoBehaviour
{
    #region Fields

    public static Action<CharacterController> CharacterCreated;

    [SerializeField] private CharacterProperties properties;
    [SerializeField] private CharacterProfileData profileData;
    public Transform followGroup;//ToDo automatically generate coordinates (depending on the count of characters)
    public float Stamina { get; private set; }
    public float FullStamina { get; private set; }
    public bool LowStamina { get; private set; }
    public bool SelectedCharacter { get; private set; }
    public CharacterProfile Profile{ get; private set; }

    private NavMeshAgent _navMeshAgent;

    private float _defaultSpeed;
    private float _maneuverability;

    private bool _followCharacter;
    private Transform _followTarget;

    #endregion

    #region PrivateMethods

    private void Start()
    {
        GenerateCharacter();

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.angularSpeed = _maneuverability;
    }

    private void Update()
    {
        if (_followCharacter)
        {
            _navMeshAgent.SetDestination(_followTarget.position);
        }
        StaminaManagement();
    }

    private void GenerateCharacter()
    {
        //generate random parameters for a character,
        //and then add the same character to the list of all characters
        
        Profile = profileData.GenerateRandomProfile();
        _maneuverability = properties.RandomManeuverability;
        _defaultSpeed = properties.RandomSpeed;
        FullStamina = properties.RandomStamina;
        Stamina = FullStamina;
        
        CharacterCreated?.Invoke(this);

        Debug.Log("New generated character: " + GetCharacterInfo().Replace("<br>", " | "));
    }

    public void Move(Vector3 targetPosition)
    {
        //motion function for the selected person
        _followCharacter = false;
        _navMeshAgent.stoppingDistance = 0;
        _navMeshAgent.SetDestination(targetPosition);
        SelectedCharacter = true;
        Debug.Log($"{gameObject.name}: move");
    }
    
    private void StaminaManagement()
    {
        //use the stamina while driving (restore the stamina after full use,
        //or when we stop (restoring the stamina will be faster when stopped))

        float currentSpeed = _navMeshAgent.velocity.magnitude;
        if (currentSpeed > 0.2f && !LowStamina)
        {
            Stamina -= Time.deltaTime;
            if (Stamina <= 0) LowStamina = true;
        }
        else
        {
            Stamina += Time.deltaTime * (currentSpeed == 0 ? 2 : 1);
            if (Stamina >= FullStamina) LowStamina = false;
        }

        Stamina = Mathf.Clamp(Stamina, 0, FullStamina);
        _navMeshAgent.speed = LowStamina ? _defaultSpeed / 2 : _defaultSpeed;
    }

    #endregion

    #region PublicMethods

    public void Follow(Transform target)
    {
        //motion function for a secondary person (set only the target,
        //and the movement is performed through an update,
        //because the position of the selected person always changes)
        
        _navMeshAgent.stoppingDistance = 2;
        _followCharacter = true;
        _followTarget = target;
        SelectedCharacter = false;
        Debug.Log($"{gameObject.name}: follow");
    }

    public string GetCharacterInfo()
    {
        return $"<b>{properties.name}</b> - {Profile.GetName}<br>" +
               $"speed: {_defaultSpeed}<br>" +
               $"stamina: {FullStamina}<br>" +
               $"maneuverability: {_maneuverability}";
    }

    public void SetSelectStatus(bool status)
    {
        SelectedCharacter = status;
    }

    #endregion
}
