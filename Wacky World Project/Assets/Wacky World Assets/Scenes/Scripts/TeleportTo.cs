using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public void MoveToPosition(Transform destination)
    {
        transform.position = destination.position;
    }
}
