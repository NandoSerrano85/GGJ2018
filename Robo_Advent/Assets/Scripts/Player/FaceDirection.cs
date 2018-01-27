using UnityEngine;
using InControl;

public class FaceDirection : MonoBehaviour
{
    private InputDevice device;

    // Use this for initialization
    private void Start ()
    {
        device = InputManager.ActiveDevice;
    }
	
	// Update is called once per frame
	private void Update ()
    {
        Vector2 move = new Vector2(device.LeftStickX, 0);
        FlipPlayerSprite(move);
    }

    private void FlipPlayerSprite(Vector2 move)
    {
        Vector2 direction = transform.localScale;

        if (move.x > 0.0f && transform.localScale.x == -1)
            direction.x *= -1.0f;
        else if (move.x < 0.0f && transform.localScale.x == 1)
            direction.x *= -1.0f;

        transform.localScale = direction;
    }
}
