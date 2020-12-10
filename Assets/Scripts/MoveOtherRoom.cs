using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MoveOtherRoom : MonoBehaviour
{
    [SerializeField] private GameObject otherRoomAnchor;
    [SerializeField] private GameObject currentRoomAnchor;
    [SerializeField] private Transform hole;
    private void OnTriggerEnter(Collider other)
    {
        TryToMoveOtherRoomBelow();
    }

    private void TryToMoveOtherRoomBelow()
    {
        var currentRoomPosition = currentRoomAnchor.transform.position;
        var otherRoomPosition = otherRoomAnchor.transform.position;
        
        // check if the other room is above this one
        if (currentRoomPosition.y > otherRoomPosition.y)
        {
            return;
        }

        hole.gameObject.SetActive(true);
        // Move the other room, bellow this one
        var roomYOffset = Mathf.Abs(otherRoomPosition.y - currentRoomPosition.y);
        otherRoomAnchor.transform.position = currentRoomPosition - new Vector3(0, roomYOffset,0);
    }
}
