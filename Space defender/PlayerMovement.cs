using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minBound;
    Vector2 maxBound;
    [SerializeField]float movementSpeed = 10f;
    [SerializeField] float paddingLeft;  
    [SerializeField]float paddingRight;
    [SerializeField]float paddingTop;
    [SerializeField]float paddingBottom;
    Shooter shooter;
    private void Awake()
    {
        shooter = FindObjectOfType<Shooter>();
    }
    void Start()
    {
        InitBoundaries();
    }
    
    void Update()
    {
        MovementCore();
    }
    
    void InitBoundaries()
    {
        Camera cam = Camera.main;
        minBound = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound= cam.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void MovementCore()
    {
        Vector3 delta = rawInput*movementSpeed*Time.deltaTime;
        Vector3 newPos= new Vector3();
        newPos.x=Mathf.Clamp(transform.position.x+delta.x, minBound.x+paddingLeft, maxBound.x-paddingRight);
        newPos.y=Mathf.Clamp(transform.position.y+delta.y, minBound.y+paddingBottom, maxBound.y-paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    
    void OnFire(InputValue value)
    {
        if (shooter.isFiring == false)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
