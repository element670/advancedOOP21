using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ButtonClick : MonoBehaviour
{
    public static readonly string ACTION = "BUTTON_CLICK";
    [SerializeField] private Button button;
    [SerializeField] private GameController.Buttons numberButton;
    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            EventBus.Trigger(ACTION, numberButton);
        });
    }
}
