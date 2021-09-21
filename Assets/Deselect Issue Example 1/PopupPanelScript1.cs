using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This is the POINTER version of the script.
/// The location of the click in the panel chooses Left or Right.
/// </summary>
public class PopupPanelScript1 : MonoBehaviour, IPointerClickHandler, IDeselectHandler
{

    private RectTransform panelRect;
 

    // Start is called before the first frame update
    void Start()
    {
        HidePanel();

        panelRect = gameObject.GetComponent<RectTransform>();
 
    }

    private void ShowAndSelectPanel() {

        if (gameObject.activeSelf) return;

        gameObject.SetActive( true );
        EventSystem.current.SetSelectedGameObject( gameObject);
	}

    private void HidePanel() {

        if (!gameObject.activeSelf) return;

        gameObject.SetActive( false );
	}

//======================================================================================================================

    // called by picker button
    public void ShowAndHidePanel() {
        if (gameObject.activeSelf) {
            HidePanel();
        }
		else {
            ShowAndSelectPanel();
		}
	}
    
    // deselect event
	public void OnDeselect(BaseEventData eventData) {

		print(">>>>> OnDeselect");

		HidePanel();
	}

    // pointer click event
	public void OnPointerClick(PointerEventData eventData) {

        print(">>>>> OnPointerClick");

        Vector2 localPt;
        RectTransformUtility.ScreenPointToLocalPointInRectangle( panelRect, eventData.position, null, out localPt );

        int pick = (int) ( 2f * (localPt.x-panelRect.rect.x) / panelRect.rect.width );

        if (pick==0) print("PICKED LEFT");
        if (pick==1) print("PICKED RIGHT");

        HidePanel();
	}
}
