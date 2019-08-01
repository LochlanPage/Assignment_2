using UnityEngine;

public class MonoBehaviourCallbacks : MonoBehaviour 
{
    private void Awake()
    {
        Debug.Log("Awake Called");
    }

    private void Start()
    {
        Debug.Log("Start Called");
    }

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        Debug.Log("Once every frame, on the frame");
    }

    private void FixedUpdate()
    {

    }

    private void LateUpdate()
    {
        Debug.Log("Once every frame, after Update");
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
