using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragDrop : MonoBehaviour //, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool isDragging = false;
    private Camera mainCamera;
    private Vector3 offset;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        isDragging = true;

        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition;
        offset = transform.position - mouseWorldPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Update object position based on mouse movement
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            transform.position = mouseWorldPosition + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        RaycastHit hit;
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = new Vector3(0, 0, 1);


        //Debug.DrawRay(rayOrigin, rayDirection * 10f, Color.red, 2f);

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 10f)) 
        {
            Debug.Log($"Raycast hit: {hit.collider.name}");

            squareHandler square = hit.collider.GetComponent<squareHandler>();
            if (square != null)
            {
                Debug.Log($"Dropped on square: {square.name}");
                Vector3 pos = new Vector3(square.transform.position.x, square.transform.position.y, -1);
                transform.position = pos; 

            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }



    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z; // Maintain object depth
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

}
