using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Penetration : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

    private void OnMouseOver()
    {
        CreateButtons.displayInfo = true;
        WinSetting.isAphaPenetrate = false;
    }

    private void OnMouseExit()
    {
        WinSetting.isAphaPenetrate = true;
    }

    // the following codes are for those instantiated buttons, since those buttons only works this way!
    public void OnPointerEnter(PointerEventData eventData)
    {
        WinSetting.isAphaPenetrate = false;
    }
    // When selected.
    public void OnPointerExit(PointerEventData eventData)
    {
        WinSetting.isAphaPenetrate = true;
    }

}
