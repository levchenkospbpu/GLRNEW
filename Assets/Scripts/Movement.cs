using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    [Inject]
    private InputManager _inputManager;
    private bool _inCollition;
    private float _collitionTime;
    private float _holdingTime;
    private bool _inTouch;
    private Vector3 _target;
    private const float DistanceToStop = 0.4f;
    private Rigidbody _rb;
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _turnSpeed = 5f;

    private void OnEnable()
    {
        _inputManager.OnStartTouch += StartTouch;
        _inputManager.OnEndTouch += EndTouch;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= StartTouch;
        _inputManager.OnEndTouch -= EndTouch;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _target = transform.position;
    }

    private void Update()
    {
        if (_inTouch)
        {
            _holdingTime += Time.deltaTime;
            SetTargetUnderTouch(_inputManager.Controls.Touch.Position.ReadValue<Vector2>());
            Debug.Log("Holding");
        }
        if (_inCollition)
        {
            _collitionTime += Time.deltaTime;
        }
        else
        {
            _collitionTime = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_target, transform.position) > DistanceToStop && _collitionTime < 0.1f)
        {
            Move();
            LookAt(_target);
        }
    }

    private void SetTargetUnderTouch(Vector2 screenPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(screenPosition), out hit))
        {
            if (hit.collider != null && hit.collider.tag == "Walkable")
            {
                _inCollition = false;
                _target = hit.point;
                _target.y = transform.position.y;
            }
        }
    }

    private void Move()
    {
        _rb.velocity = (_target - transform.position).normalized * _speed;
    }

    private void LookAt(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, _turnSpeed);
    }

    private void StartTouch(Vector2 screenPosition)
    {
        _inTouch = true;
        _holdingTime = 0;
        SetTargetUnderTouch(screenPosition);
    }

    private void EndTouch(Vector2 screenPosition)
    {
        _inTouch = false;
        if (_holdingTime >= 0.5f)
        {
            Stop();
        }
    }

    private void Stop()
    {
        _target = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Walkable")
        {
            _inCollition = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Walkable")
        {
            _inCollition = false;
        }
    }
}
