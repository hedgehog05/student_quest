using UnityEngine;

public class Player_TopDownMovement : MonoBehaviour
{
    //public int velocity;
    public int speed;

    private Vector3 movement;
    private Animator playerAnimator;

    // для PlayerPosition
    public VectorValue pos;

    void Start()
    {
        transform.position = pos.initialValue;

        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //содержит информацию по горизонтальной и вертикальной осям с клавиатуры
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Amount", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}