using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody))]
public class PlayerController_InputSystem : MonoBehaviour //bap
{
    #region Variables
#region Movement vars
    [SerializeField] private bool isBoosting = false;

    [SerializeField] private float playerSpeed = 800f; 
    [SerializeField][Range(5f, 1000f)] private float speedLimit = 7f; 
    [SerializeField][Range(0.1f, 3f)] private float limitX = 1.5f;
    [SerializeField] private float rotationSpeed = 7f;
    //private Vector3 playerVelocity;
    #endregion

    #region Jump vars
    //[SerializeField] private float gravityValue = -9.81f
    //[SerializeField] private float jumpHeight = 1.0f;
    //private bool groundedPlayer;
    #endregion

#region Gun Specifications
    [SerializeField] private float bulletMaxDistance = 40f;
    [SerializeField] public int ammoMagazine = 40;
    [SerializeField] public int ammoCurrent { get; set; }
    #endregion

#region Outer Refferences
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPointTransform;
    #endregion

# region Inner Refferences
    private PlayerInput playerInput;
    private Rigidbody rb;
    private Transform body;
    private Transform cameraTransform;
    #endregion

#region Input Actions
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction reloadAction;
    private InputAction dashAction;
    #endregion
    #endregion
    private void Awake()
    {
        body = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        reloadAction = playerInput.actions["Reload"];
        dashAction = playerInput.actions["Dash"];
    }

    private void Start()
    {
        ammoCurrent = ammoMagazine;
    }

    private void OnEnable()
    { 
        shootAction.performed += _ => ShootGun();
        reloadAction.performed += _ => Reload();
        dashAction.performed += _ => DashEnabled();
        dashAction.canceled += _ => DashDisabled();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => ShootGun();
        reloadAction.performed -= _ => Reload();
    }

    private void ShootGun()
    {
        if (ammoCurrent > 0)
        {
            RaycastHit hit;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPointTransform.position, Quaternion.identity);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
            {
                bulletController.target = hit.point;
                bulletController.hit = true;
            }
            else
            {
                bulletController.target = cameraTransform.position + cameraTransform.forward * bulletMaxDistance;
                bulletController.hit = false;
            }
            ammoCurrent -= 1;
            
        }
        
    }

    private void Reload()
    {
        ammoCurrent = ammoMagazine;
    }

    private void DashEnabled()
    {
        isBoosting = true;
    }

    private void DashDisabled()
    {
        isBoosting = false;
    }

    private void Move() //Movement & rotation
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * body.right.normalized + move.z * body.forward.normalized;
        move.y = 0f;

        switch (isBoosting)
        {
            case false:
                if (rb.linearVelocity.magnitude <= speedLimit)
                {
                    rb.AddForce(move * playerSpeed * Time.deltaTime);
                }
                break;
            case true:
                if (rb.linearVelocity.magnitude <= speedLimit * limitX)
                {
                    rb.AddForce(move * playerSpeed * Time.deltaTime);
                }
                break;
        }

        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }



    void Update()
    {
        #region //Move + Jump
        //controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        //if (jumpAction.triggered && groundedPlayer)  //jumpAction.triggered == Input.GetButtonDown("Jump");
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
        #endregion

        Move();
    }
}