using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler
{
    private Transform _origParent;
    private bool _mouseIsHeldDown;
    private Vector3 _previousMousePosition;
    private bool _isDragging;
    
    private void Start()
    {
        _origParent = transform.parent;
    }

    private void Update()
    {
        if (_mouseIsHeldDown)
        {
            if (Input.mousePosition != _previousMousePosition)
            {
                StartDragging();
            }

            if (Input.GetMouseButtonUp(0))
            {
                HandleMouseRelease();
            }

            if (_isDragging)
            {
                transform.position = Input.mousePosition;
            }
        }
    }

    private void StartDragging()
    {
        _isDragging = true;
        transform.SetParent(_origParent.parent);
    }

    private void HandleMouseRelease()
    {
        var characterCardArea = CheckIfMouseIsOverCharacterCardArea();
        _mouseIsHeldDown = false;
        _isDragging = false;
        if (characterCardArea != null)
        {
            transform.SetParent(characterCardArea.transform);
            characterCardArea.PlaceCard(GetComponent<Card>());
            enabled = false;
        }
        else
        {
            transform.SetParent(_origParent);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button != PointerEventData.InputButton.Left)
            return;
        
        _mouseIsHeldDown = true;
        _previousMousePosition = Input.mousePosition;
    }
    
    public static CharacterCardArea CheckIfMouseIsOverCharacterCardArea()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        CharacterCardArea dropZone = null;
        foreach (var raycastResult in raycastResults)
        {
            raycastResult.gameObject.TryGetComponent(out dropZone);
        }

        return dropZone;
    }
}
