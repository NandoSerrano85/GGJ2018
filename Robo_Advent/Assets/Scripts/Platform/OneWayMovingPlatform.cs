using UnityEngine;

public class OneWayMovingPlatform : BasePlatform2DController
{
    protected override void Start()
    {
        base.Start();
        platformRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    protected override void movePlatform()
    {
        
    }
}
