using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragDrop : MonoBehaviour //, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool isDragging = false;
    private Camera mainCamera;
    private Vector3 offset;

    public RenderPieces renderPieces;
    public PieceTracker pieceTracker;

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
            if (castRay(transform.position, new Vector3(0, 0, 1), out RaycastHit hit))
            {
                squareHandler square = hit.collider.GetComponent<squareHandler>();
                if (int.TryParse(square.name, out int square_index))
                {
                    pieceTracker.posList[square_index] = 0;
                }
                
            }
            // Update object position based on mouse movement
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            transform.position = mouseWorldPosition + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        bool collided = castRay(transform.position, new Vector3(0, 0, 1), out RaycastHit hit);
        if (collided)
        {
            squareHandler square = hit.collider.GetComponent<squareHandler>();
            snapPieceToPosition(square);
            updateBoard(square);
        }

        else
        {
            Debug.Log("Raycast did not detect any collision boxes!");
        }
    }

    private bool castRay(Vector3 rayOrigin, Vector3 rayDirection, out RaycastHit hit)
    {
        bool collided = Physics.Raycast(rayOrigin, rayDirection, out hit, 10f);
        return collided;
    }

    private void snapPieceToPosition(squareHandler square)
    {
        if (square != null)
        {
            Vector3 pos = new Vector3(square.transform.position.x, square.transform.position.y, -1);
            transform.position = pos;
        }
    }

    private void updateBoard(squareHandler square)
    {
        int square_index;
        bool index = int.TryParse(square.name, out square_index);
        string targetPiece = gameObject.name;
        int pieceValue = -1;

        foreach (var kvp in renderPieces.pieces)
        {
            if (kvp.Value.name == targetPiece)
            {
                pieceValue = kvp.Key;
            }
        }

        if (index)
        {
            pieceTracker.posList[square_index] = pieceValue;
            Debug.Log($"Updated board by changing square {square.name}'s value to {pieceValue}. This means that there is now a {gameObject.name} on square {square.name}!");
        }
    }



    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z; 
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

}
