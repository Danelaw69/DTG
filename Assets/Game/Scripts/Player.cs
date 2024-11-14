using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private PlayerActions _playerControls;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;
    // Start is called before the first frame update

    void Awake()
    {
        _playerActions = new PlayerActions();

        _rbody = GetComponent<Rigidbody2D>();
        if (_rbody is null)
            Debug.LogError("RigidBody2D is NULL!");
    }
    private void OnEnable()
    {
        _playerActions.Gameplay.Enable();
    }
    private void OnDisable()
    {
        _playerActions.Gameplay.Disable();
    }
    private void FixedUpdate()
    {
        Vector2 input = PlayerActions.actions[Movement].ReadValue<Vector2>();
        _rbody.velocity = _moveInput * _speed;
    }
    void Start()
    {
        //_moveInput = _playerActions.Gameplay.Movement.ReadValue<Vector2>();
        //_rbody.velocity = _moveInput * _speed;
        PlayerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
