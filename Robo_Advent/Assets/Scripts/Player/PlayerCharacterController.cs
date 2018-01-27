using UnityEngine;
using InControl;

public class PlayerCharacterController : BaseEntity2DController
{
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float jumpTakeOffSpeed = 10;

    public PlayerStats playerStats { get; private set; }

    private InputDevice device;

    private bool wasPreviouslyGrounded;

    private Animator playerAnimator;
    private PlayerSoundEffectsController playerSoundEffectsController;

    protected override void Awake()
    {
        base.Awake();
        playerStats = PlayerPersistence.LoadData();
        playerAnimator = GetComponent<Animator>();
        playerSoundEffectsController = GetComponent<PlayerSoundEffectsController>();
        device = InputManager.ActiveDevice;
    }

    private void Start()
    {
        if (playerSoundEffectsController != null)
            playerSoundEffectsController.PlaySoundEffect(Soundeffects.Teleport);
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = new Vector2(device.LeftStickX, 0);

        bool jumpButtonPressed = device.Action4.WasPressed;
        bool jumpButtonReleased = device.Action4.WasReleased;

        if (grounded)
        {
            CheckIfPreviouslyGrounded();

            if (jumpButtonPressed)
                jump();
        }
        else if (jumpButtonReleased)
        {
            ReduceVelocity();
        }

        wasPreviouslyGrounded = !grounded;

        SetPlayerAnimations();

        targetVelocity = move * maxSpeed;
    }

    private void jump()
    {
        velocity.y = jumpTakeOffSpeed;

        if(playerSoundEffectsController != null)
            playerSoundEffectsController.PlaySoundEffect(Soundeffects.Jump);
    }

    private void ReduceVelocity()
    {
        if (velocity.y > 0)
        {
            velocity.y = velocity.y * 0.5f;
        }
    }

    private void CheckIfPreviouslyGrounded()
    {
        if(wasPreviouslyGrounded)
        {
            wasPreviouslyGrounded = false;

            if (playerSoundEffectsController != null)
                playerSoundEffectsController.PlaySoundEffect(Soundeffects.Landing);
        }
    }

    private void SetPlayerAnimations()
    {
        if(playerAnimator != null)
        {
            playerAnimator.SetBool("Ground", grounded);
            playerAnimator.SetFloat("VelocityY", velocity.y);
            playerAnimator.SetFloat("VelocityX", Mathf.Abs(velocity.x) / maxSpeed);
        }
    }
}
