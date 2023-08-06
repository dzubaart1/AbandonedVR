using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketCntrl : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor _socketInteractor;
    
    public void OnSelectItem()
    {
        var disappearanceItemCntrl =
            _socketInteractor.interactablesSelected[0]?.transform.GetComponent<DisappearanceItemCntrl>();
        if (disappearanceItemCntrl)
        {
            disappearanceItemCntrl.ActivateItem();
        }
    }
}
