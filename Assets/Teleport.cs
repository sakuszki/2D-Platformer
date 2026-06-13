using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform destination;
    //public Vector3 destination;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = destination.position;
        //collision.transform.position = destination;

    }
    //private void OnDrawGizmosSelected()
    //{
    // Gizmos.color = Color.red;
    // Gizmos.DrawSphere(destination, 1);
    //}
}