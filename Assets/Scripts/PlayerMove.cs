using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Player))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private Player player;
    private Animator animator;

    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            float h = Input.GetAxis("LHorizontal" + player.playerId);
            float v = -Input.GetAxis("LVertical" + +player.playerId);

            moveDirection = (h * right + v * forward);
            moveDirection *= speed;
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);

            //if (Input.GetButton("AButton" + player.playerId))
            //{
            //    moveDirection.y = jumpSpeed;
            //}

            

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);




        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal" + player.playerId) + Vector3.forward * -Input.GetAxisRaw("RVertical" + player.playerId);
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }
    }


 


}