using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private AudioClip _audioWheelSpin;
    [SerializeField] private AudioClip _audioScull;
    [SerializeField] private AudioClip _audioAward;
    [SerializeField] private AudioClip _audioCollect;

    public void StartWheelSpin()
    {
        _audioSource.clip = _audioWheelSpin;
        _audioSource.loop = true;
        _audioSource.pitch = 1f;
        _audioSource.Play();
    }

    public void SetWheelSpinPitch(float pitch)
    {
        _audioSource.pitch = pitch;
    }

    public void StopWheelSpin()
    {
        _audioSource.Stop();
        _audioSource.loop = false;
        _audioSource.pitch = 1f;
    }

    public void PlayScull()
    {
        _audioSource.clip = _audioScull;
        _audioSource.PlayDelayed(1f);
    }

    public void PlayAward()
    {
        _audioSource.clip = _audioAward;
        _audioSource.PlayDelayed(1f);
    }
    
    public void PlayCollect()
    {
        _audioSource.clip = _audioCollect;
        _audioSource.PlayDelayed(1.5f);
    }
}