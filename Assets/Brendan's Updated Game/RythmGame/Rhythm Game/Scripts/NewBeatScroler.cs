using UnityEngine;

public class NewBeatScroler : MonoBehaviour
{
    [Tooltip("Units per second that arrows should move")]
    public float scrollSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
    }
}
