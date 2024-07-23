using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatsToTapScript : MonoBehaviour
{
    public float downSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 downwardMovement = Vector2.down * downSpeed * Time.deltaTime;

        transform.position += (Vector3)downwardMovement;

        if(this.gameObject.transform.position.y < -17)
        {
            Destroy(this.gameObject);
        }
    }
}
