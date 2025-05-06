using UnityEngine;

public class PlayerControlScripts : MonoBehaviour
{
    [SerializeField] private Transform _orientationTransform;
    private Rigidbody _playerRigidBody;

    private float _horizontalInput, _verticalInput;
    private Vector3 _movementDirection;

    void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerRigidBody.freezeRotation = true;
    }

    private void Update()
    {
        SetInputs();
    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void SetPlayerMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalInput + _orientationTransform.right * _horizontalInput;

        _playerRigidBody.AddForce(_movementDirection * 20f, ForceMode.Force);

    }
}
