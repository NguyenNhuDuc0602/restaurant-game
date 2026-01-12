using UnityEngine;

public class Chef : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float moveSpeed = 0.2f;
    [SerializeField] float steerSpeed = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float changeSteer = Input.GetAxis("Horizontal") * steerSpeed;
        float changeSpeed = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(0, changeSpeed, 0);
        transform.Rotate(0,0, -changeSteer);
    }
}
