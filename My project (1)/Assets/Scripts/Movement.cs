using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Light flashlight;
    public GameObject player;
    public Vector3 respawnPosition, respawnOrientation;
    public Image deathOverlay;
    public Camera mainCamera;
    private float speed = 12f;
    private Vector3 cameraPosition;
    private Vector3 cameraRotation;
    public float walking_speed = 12f;
    public float sprinting_speed = 25f;
    public float gravity = -40f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask deathMask;
    bool isGrounded;
    bool shouldDie, isDead;
    bool triggerRespawn = true;

    public float jumpHeight = 3f;
    private float epsilon = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        triggerRespawn = false;
        deathOverlay.color = new Color(0.0f,0.0f,0.0f,0.0f);
        isDead = false;
        float[] distances = new float[32];
        distances[6] = 3000.0f;
        mainCamera.layerCullDistances = distances;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerRespawn)
        {
            mainCamera.transform.position = cameraPosition;
            mainCamera.transform.rotation = Quaternion.Euler(cameraRotation);
            player.transform.position = respawnPosition;
            player.transform.rotation = Quaternion.Euler(respawnOrientation);
            controller.transform.position = respawnPosition;
            controller.transform.rotation = Quaternion.Euler(respawnOrientation);
            shouldDie = false;
            isDead = false;
            deathOverlay.color = new Color(0.0f,0.0f,0.0f,0.0f);
            triggerRespawn = false;
        }
        shouldDie = Physics.CheckSphere(groundCheck.position, groundDistance, deathMask);
    }

    void Update()
    {
        if(shouldDie || isDead)
        {
            if(!isDead && !triggerRespawn){
                epsilon = 0.0f;
                cameraPosition = mainCamera.transform.position;
                cameraRotation = (mainCamera.transform.rotation).eulerAngles;
                isDead = true;
            }
            mainCamera.transform.rotation = Quaternion.Euler(Vector3.Lerp(cameraRotation, new Vector3(cameraRotation.x, cameraRotation.y, cameraRotation.z + 90), epsilon));
            mainCamera.transform.position = Vector3.Lerp(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y - 1.6f, cameraPosition.z), epsilon);
            deathOverlay.color = new Color(0.0f,0.0f,0.0f,Mathf.Clamp((epsilon - 0.5f) * 3.0f, 0.0f, 1.0f));
            if (epsilon < 1.0f)
            {
                epsilon += 0.3f * Time.deltaTime;
            }
            else
            {
                triggerRespawn = true;
                isDead = false;
                shouldDie = false;
            }
        }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if(isGrounded)
            {
                velocity.y = -2f;
            }
            
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            
            if(Input.GetButton("Sprint"))
            {
                speed = sprinting_speed;
            }
            else
            {
                speed = walking_speed;
            }
            
            controller.Move(move * speed * Time.deltaTime);
            if(Input.GetButton("Jump") && isGrounded)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}