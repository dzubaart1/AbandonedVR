using System;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsBtnCntrl : MonoBehaviour
{
    [SerializeField] private float _deadZone;
    [SerializeField] private float _threshold;
    
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent OnReleased, OnPressed;
    
    private void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        var value = GetValue();
        
        if (!_isPressed && value + _threshold >= 1)
        {
            Pressed();
        }

        if (_isPressed && value - _threshold <= 0)
        {
            Released();
        }
    }

    private void Pressed()
    {
        _isPressed = true;
        OnPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        OnReleased.Invoke();
        Debug.Log("Released");
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < _deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }
}
