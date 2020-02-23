using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonSelector : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IDeselectHandler
{
    [SerializeField] private GameObject selector;

    // Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        selector.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Select this button when moused over
        if (!EventSystem.current.alreadySelecting)
            EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // things to do when a button is deselected
        selector.SetActive(false);
        this.GetComponent<Selectable>().OnPointerExit(null);
    }
}