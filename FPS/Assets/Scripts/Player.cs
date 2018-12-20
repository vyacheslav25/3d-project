using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	    [Range(1, 30)] public byte Speed;
        [Range(0.1f, 5)] public float Gravity;
        [Range(0.1f, 5)] public float JumpForce;
        
        public float Sensitivity;    
        public Animator anim;
        public float v;
        public float h;
        public float moveAmount;    
    
        private CharacterController Controller;
        private Vector3 MoveDirection;
        private Vector3 CameraRotation;
        private Transform CameraTransform;
    
        
        
    
        private void Start()
        {
            CameraTransform = Camera.main.transform;
            Controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        private void Update()
        {
            Move();
            Rotate();
            Shoot();
        }
    
        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.DrawRay(CameraTransform.position, CameraTransform.forward * 100, Color.red);
                Ray ray = new Ray(CameraTransform.position, CameraTransform.forward * 100);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
        
        private void Rotate()
        {
            float sens = Sensitivity * Time.deltaTime;
            float mouseX = Input.GetAxis("Mouse X") * sens;
            transform.Rotate(Vector3.up * mouseX);
            float mouseY = Input.GetAxis("Mouse Y") * sens;
            CameraRotation.x -= mouseY;
            CameraRotation.x = Mathf.Clamp(CameraRotation.x, -75, 50);
            CameraTransform.localEulerAngles = CameraRotation;
    
        }
    
        public void Move()
        {
            if (Controller.isGrounded)
            {
                h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");
                 moveAmount = Mathf.Clamp01(Mathf.Abs(v) + Mathf.Abs(h));
                anim.SetFloat("vertical",v,0.15f, Time.deltaTime);
                
                
                MoveDirection = new Vector3(h, 0, v);
                MoveDirection = transform.TransformDirection(MoveDirection);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    MoveDirection.y = JumpForce;
                }
            }
            MoveDirection.y -= Gravity * Time.deltaTime;
            Controller.Move(MoveDirection * Speed * Time.deltaTime);
        }
}
