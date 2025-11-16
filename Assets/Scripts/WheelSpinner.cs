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
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private SoundsManager _soundsManager;

    public event Action OnSpinEnd;
    public event Action OnSpinStart; 

    private bool _isSpinning = false;
    private float _currentSpeed;
    private float _currentAngle;


    private void Update()
    {
        if (_isSpinning)
        {
            transform.Rotate(0,0, -_currentSpeed * Time.deltaTime);
            _currentSpeed -= _deceleration * Time.deltaTime;

            float normalizedSpeed = _currentSpeed / _maxSpeed;
            float pitch = Mathf.Lerp(0.5f, 1.2f, normalizedSpeed);
            _soundsManager.SetWheelSpinPitch(pitch);

            if (_currentSpeed <= 0)
            {
                _soundsManager.StopWheelSpin();
                
                _isSpinning = false;
                _currentSpeed = 0;

                _currentAngle = transform.eulerAngles.z;
                _particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                
                OnSpinEnd?.Invoke();
            }
        }
    }

    public void Spin()
    {
        if (_isSpinning)
        {
            return;
        }
        
        OnSpinStart?.Invoke();
        
        _soundsManager.StartWheelSpin();
        _isSpinning = true;
        _spinButtonView.SetInteractable(false);
        _animator.SetTrigger(FlyToSpin);
        _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
        _particle.Play();
    }
}