using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BarrelExitButton : MonoBehaviour
{
    private Button button;
    private HideBarrel barrel;

    private void Awake()
    {
        button = GetComponent<Button>();
        barrel = GetComponentInParent<HideBarrel>();
        button.onClick.AddListener(ExitBarrel);
    }

    private void ExitBarrel()
    {
        if (barrel != null)
        {
            barrel.PlayerExitedBarrel();
        }
    }
}
