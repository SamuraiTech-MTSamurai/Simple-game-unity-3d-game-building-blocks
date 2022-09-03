using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity =3.6f;
    float cameraPitch = 0.0f;

    [SerializeField] bool lockCursor = true;

    [SerializeField] float run = 14;

    CharacterController controller = null;

    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -14.0f;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    float velocityY = 0.0f;
    float SuperRun = 24;
    float jumpF = 50;
   
    


    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
      if (lockCursor)
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

      }

    }

    // Update is called once per frame
    void Update()
    {
      UpdateMouselook();
      UpdateMovement();
      

    }

    void UpdateMouselook()
    {
      Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

      cameraPitch -= mouseDelta.y * mouseSensitivity;

      cameraPitch = Mathf.Clamp(cameraPitch, -90.0f , 90.0f);

      playerCamera.localEulerAngles = Vector3.right * cameraPitch;

      transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        if (Input.GetKey (KeyCode.LeftShift)) {
         run = 30;

        }

         else{
             run = 14;}
          





     Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

     currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

     Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * run + Vector3.down *gravity* velocityY;

     controller.Move(velocity * Time.deltaTime);

     if(controller.isGrounded)
        {velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;}



        
    }
    

}

//made by mohammed yusuf timol


        
        

         






  
    

    
    
      

    

