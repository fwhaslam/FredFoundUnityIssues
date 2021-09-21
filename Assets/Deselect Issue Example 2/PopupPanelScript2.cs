using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This is the BUTTON version of the script.
/// Buttons pick Left or Right.
/// </summary>
public class PopupPanelScript2 : MonoBehaviour, IDeselectHandler
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

    public void PickLeft() {
        print("PICKED LEFT");
        HidePanel();
	}

    public void PickRight() {
        print("PICKED RIGHT");
        HidePanel();
	}
}
