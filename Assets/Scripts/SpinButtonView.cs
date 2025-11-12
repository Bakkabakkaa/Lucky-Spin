using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinButtonView : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _button;
    [SerializeField] private Color _dimColor = new Color(1, 1, 1, 0.5f);
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void SetInteractable(bool value)
    {
        _button.interactable = value;
        _buttonImage.color = value ? Color.white : _dimColor;
        _buttonText.color = value ? Color.white : new Color(1,1,1,0.5f);
    }
}
