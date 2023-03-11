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
        var characterCardArea = CheckIfMouseIsOverAreaWithTag("CharacterCardArea");
        _mouseIsHeldDown = false;
        _isDragging = false;
        if (characterCardArea != null)
        {
            var area = characterCardArea.GetComponent<CharacterCardArea>();
            transform.SetParent(area.transform);
            area.PlaceCard(GetComponent<Card>());
            return;
        }

        var trashCardArea = CheckIfMouseIsOverAreaWithTag("TrashCardArea");
        if (trashCardArea != null)
        {
            ResourceManager.GainResource(1);
            Destroy(gameObject);
        }
        
        transform.SetParent(_origParent);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button != PointerEventData.InputButton.Left)
            return;
        
        _mouseIsHeldDown = true;
        _previousMousePosition = Input.mousePosition;
    }
    
    public static GameObject CheckIfMouseIsOverAreaWithTag(string tag)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        foreach (var raycastResult in raycastResults)
        {
            var resultGameObject = raycastResult.gameObject;
            if (resultGameObject.CompareTag(tag))
                return resultGameObject;
        }

        return null;
    }
}
