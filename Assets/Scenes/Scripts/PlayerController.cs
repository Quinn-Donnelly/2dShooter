using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        print(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var velocity = _rigidbody2D.velocity;
            velocity = new Vector2(velocity.x, velocity.y + jumpVelocity);
            _rigidbody2D.velocity = velocity;
        }
    }
}
