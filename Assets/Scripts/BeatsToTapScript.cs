using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatsToTapScript : MonoBehaviour
{
    public float downSpeed = 3f;
    public AudioClip tapSound;

    // Update is called once per frame
    void Update()
    {
        Vector2 downwardMovement = Vector2.up * downSpeed * Time.deltaTime;
        transform.position += (Vector3)downwardMovement;

        if(gameObject.transform.position.y > 17)
        {
            Destroy(gameObject);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            if(hitCollider != null && hitCollider.gameObject == gameObject)
            {
                TapManager.Instance.PlaySound(tapSound);
                Destroy(gameObject);
            } 
        }

        #if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                SoundManager.Instance.PlaySound(destroySound);
                Destroy(gameObject);
            }
        }
        #endif
    }
}
