using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatControl : MonoBehaviour
{
    public GameObject effect;
    public float fMoveSpeed = 5.0f;
    private Vector3 rawPosition;
    private Vector3 hatPosition;
    private float fMaxWidth;

    private Vector3 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sceenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(sceenPos);
        float fBallWidth = GetComponent<Renderer>().bounds.extents.x;

        fMaxWidth = moveWidth.x - fBallWidth;

        deltaPos = Camera.main.transform.position - transform.position;

        // Debug.Log(deltaPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //hatPosition = rawPosition;
        //hatPosition.z = 0;

        //hatPosition.x = Mathf.Clamp(hatPosition.x, -fMaxWidth, fMaxWidth);

        //GetComponent<Rigidbody2D>().MovePosition(hatPosition);

        //Camera.main.transform.position = transform.position + deltaPos;
    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * fMoveSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * fMoveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * fMoveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * fMoveSpeed);
        }


        Vector3 headPos = gameObject.transform.localPosition;
        Vector3 normal = JoyStickController.instance.GetDirction();

        float tickTime = Time.deltaTime * fMoveSpeed;
        gameObject.transform.localPosition = new Vector3(headPos.x + normal.x * tickTime, headPos.y + normal.y * tickTime, headPos.z);

        Camera.main.transform.position = transform.position + deltaPos;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ball"))
        {
            GameObject newEffect = Instantiate(effect, transform.position, transform.rotation);
            newEffect.transform.parent = transform;

            Destroy(newEffect, 1.0f);
            Destroy(collision.gameObject);
        }
        
    }
}
