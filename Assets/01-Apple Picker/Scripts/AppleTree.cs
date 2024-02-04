using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Apple prefab
    public GameObject applePrefab;

    //speed of movement
    public float speed = 1f;

    //boundary
    public float edge = 10f;

    //chance to turn
    public float chanceToChangeDirections = .1f;

    //drop apple frequency
    public float seconds = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -edge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > edge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
    
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", seconds);
    }
}
