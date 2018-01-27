using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class BasePlatform2DController : MonoBehaviour
{
    [SerializeField] protected List<Vector2> wayPoints;
    protected Rigidbody2D platformRigidbody;
    protected bool isMovingPlatform = true;
    protected bool isLooping = false;

	// Use this for initialization
	protected virtual void Start ()
    {
        platformRigidbody = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        movePlatform();
    }
    
    protected virtual void movePlatform()
    {
    }
}
