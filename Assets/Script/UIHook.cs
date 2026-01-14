using UnityEngine;

public class UIHook : MonoBehaviour
{
    public void OnUpgradeClick()
    {
        GameManager.I.TryUpgrade();
    }

    public void OnResetClick()
    {
        GameManager.I.ResetAll();
    }
}
