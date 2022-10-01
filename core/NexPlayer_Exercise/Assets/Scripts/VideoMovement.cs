using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class VideoMovement : MonoBehaviour
{
    [SerializeField] [Tooltip("Vertical limits for the movement")]
    private Collider [] vertLimits;
    
    [SerializeField] [Tooltip("Horizontal limits for the movement")]
    private Collider [] horLimits;
    
    [SerializeField] [Tooltip("Initial force to movement")]
    private float movForce = 300;

    [SerializeField] [Tooltip("Initial force to rotation")]
    private float angForce = 0.5f;
    
    [SerializeField] [Tooltip("This rigidbody")]
    private Rigidbody rb;
    
    // Movement diretion
    private Vector2 movDir;
    // Angular direction
    private Vector2 angDir;
    // Initial position
    private Vector3 initialPos;
    // Initial rotation
    private Quaternion initialRot;
    
    private bool isPlay = true;
    
    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        
        movDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * movForce;
        rb.AddForce(movDir);
        
        angDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * angForce;
        rb.AddTorque(angDir, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        var vel = rb.velocity;
        if (other == vertLimits[0] || other == vertLimits[1])
        {
            vel.y = -vel.y;
        }
        else if(other == horLimits[0] || other == horLimits[1])
        {
            vel.x = -vel.x;
        }
    
        rb.velocity = vel;
    }

    public void PlayPauseObject()
    {
        isPlay = !isPlay;
        if (isPlay)
        {
            movDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * movForce;
            rb.AddForce(movDir);
        
            angDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * angForce;
            rb.AddTorque(angDir, ForceMode.Impulse);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void Reset()
    {
        isPlay = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPos;
        transform.rotation = initialRot;
    }
}