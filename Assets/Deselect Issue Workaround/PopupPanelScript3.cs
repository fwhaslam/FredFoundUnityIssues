using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This is the WORKAROUND version of the script.
/// The deselect event is ignored if it falls in the button or the panel.
/// </summary>
public class PopupPanelScript3 : MonoBehaviour, IDeselectHandler
{

    // WORKAROUND: need to examine popupButton
    public GameObject popupButton;

    private RectTransform panelRect,buttonRect;
 

    // Start is called before the first frame update
    void Start()
    {
        HidePanel();

        panelRect = gameObject.GetComponent<RectTransform>();
        buttonRect = popupButton.GetComponent<RectTransform>();
 
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

        // WORKAROUND: if the deselect click was in either the panel or the button then ignore.
        if ( eventData.GetType()==typeof(PointerEventData) ) {
            Vector2 click = ((PointerEventData)eventData).position;
            if (RectTransformUtility.RectangleContainsScreenPoint( panelRect, click )) return;
            if (RectTransformUtility.RectangleContainsScreenPoint( buttonRect, click )) return;
		}

		HidePanel();
	}

    public void PickLeft() {
        print("PICKED LEFT");
        HidePanel();
	}

    public void PickRight() {
        print("PICKED RIGHT");
        HidePanel();
	}
}
