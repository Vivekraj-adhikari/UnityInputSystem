using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    PlayerControls controls;
    Vector2 movement;
    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += context => movement = (context.ReadValue<Vector2>());
        controls.Player.Move.canceled += context => movement = Vector2.zero;
    }

    private void OnEnable(){
        controls.Player.Enable();
    }

    private void OnDisable(){
        controls.Player.Disable();
    }

    void SendMessage(Vector2 coordinates){
        Debug.Log("Coordinates: " + coordinates);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(movement.x, 0.0f, movement.y) * speed * Time.deltaTime;
        transform.Translate(moveVector, Space.World);
    }
}
