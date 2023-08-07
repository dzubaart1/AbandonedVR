using System;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsBtnCntrl : MonoBehaviour
{
    [SerializeField] private float _deadZone;
    [SerializeField] private float _threshold;
    
    private bool _isPressed, _isGameStart;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent OnReleased;

    public void OnStartGame()
    {
        _isGameStart = true;
    }
    private void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if (_isGameStart && _isPressed && GetValue() - _threshold <= 0)
        {
            Released();
        }
    }

    private void Released()
    {
        _isPressed = false;
        OnReleased.Invoke();
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
