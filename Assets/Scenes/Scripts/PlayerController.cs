using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float airMoveSpeed;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private GameObject e;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        print(this);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    private void PlayerControls()
    {
        JumpControls();
        MovementControls();
        CombatControls();
    }

    private void CombatControls()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 postition = transform.position;
            postition.y += 1;
            postition.x += 1;
            Instantiate(e, postition, Quaternion.Euler(0, 0, -90));
        }
    }

    private void MovementControls()
    {
        var velocity = _rigidbody2D.velocity;
        
        if (Input.GetKey(KeyCode.D))
        {
            if (!IsGrounded())
            {
                velocity += new Vector2(+movementSpeed * airMoveSpeed * Time.deltaTime, 0);
                _rigidbody2D.velocity =
                    new Vector2(Mathf.Clamp(velocity.x, -movementSpeed, +movementSpeed), velocity.y);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(+movementSpeed, velocity.y);   
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (!IsGrounded())
            {
                velocity += new Vector2(-movementSpeed * airMoveSpeed * Time.deltaTime, 0);
                _rigidbody2D.velocity =
                    new Vector2(Mathf.Clamp(velocity.x, -movementSpeed, +movementSpeed), velocity.y);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(-movementSpeed, velocity.y);   
            }
        }
        else if (IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(0, velocity.y);
        }
    }
    
    private void JumpControls()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }
    }
    
    private bool IsGrounded()
    {
        var position = transform.position;
        Collider2D overlap = Physics2D.OverlapCircle(groundCheck.bounds.center, groundCheck.size.y, platformLayerMask);
        // ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
        return overlap;
    }
}
