using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelSpinner : MonoBehaviour
{
    private static readonly int FlyToSpin = Animator.StringToHash("FlyToSpin");
    [SerializeField] private float _minSpeed = 400f;
    [SerializeField] private float _maxSpeed = 800f;
    [SerializeField] private float _deceleration = 100f;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpinButtonView _spinButtonView;

    private bool _isSpinning = false;
    private float _currentSpeed;
    private float _currentAngle;


    private void Update()
    {
        if (_isSpinning)
        {
            transform.Rotate(0,0, -_currentSpeed * Time.deltaTime);
            _currentSpeed -= _deceleration * Time.deltaTime;

            if (_currentSpeed <= 0)
            {
                _isSpinning = false;
                _currentSpeed = 0;

                _currentAngle = transform.eulerAngles.z;
                _spinButtonView.SetInteractable(true);
            }
        }
    }

    public void Spin()
    {
        if (_isSpinning)
        {
            return;
        }

        _isSpinning = true;
        _spinButtonView.SetInteractable(false);
        _animator.SetTrigger(FlyToSpin);
        _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
    }
}
