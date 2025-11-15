using UnityEngine;

public class SpinButtonController : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private SpinButtonView _spinButtonView;
    
    public void OnAwardAnimationEnd()
    {
        if (_uiManager.TokensCount > 0)
        {
            _spinButtonView.SetInteractable(true);
        }
    }
}