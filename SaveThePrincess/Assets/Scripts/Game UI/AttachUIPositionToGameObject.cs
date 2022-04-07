using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachUIPositionToGameObject : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private RectTransform canvasRect;

    [SerializeField]
    private Vector2 offset;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        AttachPosition();
    }

    private void AttachPosition()
    {
        float offsetPosX = target.transform.position.x + offset.x;
        float offsetPosY = target.transform.position.y + offset.y;
        Vector3 offsetPos = new Vector3(offsetPosX, offsetPosY, target.transform.position.z);

        Vector2 canvasPos;
        Vector2 screenPoint = mainCamera.WorldToScreenPoint(offsetPos);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

        transform.localPosition = canvasPos;
    }
}
