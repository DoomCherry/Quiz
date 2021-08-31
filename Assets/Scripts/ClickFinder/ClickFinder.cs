using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.ClickFinder
{
    public class ClickFinder : MonoBehaviour
    {
        [SerializeField ]private int maxRayClickDistance = 1000;
        [SerializeField] private LayerMask CellButton;
        private Camera _mainCamera;
        void Start()
        {
            _mainCamera = Camera.main;
        }

        void FixedUpdate()
        {
            RaycastHit hitInfo;
            Vector3 mousePositionInWorldSpace = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 endDir = mousePositionInWorldSpace + Vector3.forward * maxRayClickDistance;
            if (Physics.Raycast(mousePositionInWorldSpace, endDir, out hitInfo, maxRayClickDistance, CellButton, QueryTriggerInteraction.Collide) && Input.GetMouseButton(0))
            {
                CellButton buttonCollider = hitInfo.collider.GetComponent<CellButton>();
                buttonCollider.Click();
            }
        }
    }
}
