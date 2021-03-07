using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform _transform;
    private Vector3 _spawn;
    [SerializeField] private float maxDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        _spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_spawn, transform.position) >= maxDistance)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
