using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent (typeof(ARRaycastManager))]
[RequireComponent (typeof(ARPlaneManager))]
public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab = default;

    [Space]

    [SerializeField] private GameObject target = default;

    [Space]

    private Vector2 raycastPosition;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private ARRaycastManager aRRaycastManager;

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();

        raycastPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.5f);
    }

    private void Update()
    {
        if (aRRaycastManager.Raycast(raycastPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            target.transform.position = hitPose.position;

            if (!target.activeInHierarchy)
                target.SetActive(true);

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                Instantiate(objectPrefab, hitPose.position, hitPose.rotation);
        }

        else
        {
            if (target.activeInHierarchy)
                target.SetActive(false);
        }
    }
}