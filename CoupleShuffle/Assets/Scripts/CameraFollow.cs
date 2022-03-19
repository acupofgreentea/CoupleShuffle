using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    [Range(0.1f, 1f)]
    [SerializeField] private float followSpeed;

    private Vector3 velocity = Vector3.zero;

    private Transform player;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() 
    {
        var desiredPosition = player.position + offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
    }
}