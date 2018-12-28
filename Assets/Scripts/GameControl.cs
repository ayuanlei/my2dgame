using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject ball;
    private float fMaxWidth;
    private float fTime;
    private GameObject newBall;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sceenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(sceenPos);
        float fBallWidth = ball.GetComponent<Renderer>().bounds.extents.x;

        fMaxWidth = moveWidth.x - fBallWidth;

        Debug.Log(Screen.width);
        Debug.Log(fMaxWidth);
    }

    private void FixedUpdate()
    {
        fTime -= Time.deltaTime;
        if(fTime<0)
        {
            fTime = Random.Range(1.5f, 2.0f);
            float posX = Random.Range(-fMaxWidth, fMaxWidth);
            Vector3 spawPos = new Vector3(posX, transform.position.y, 0);

            newBall = Instantiate(ball, spawPos, Quaternion.identity);

            Destroy(newBall, 10.0f);

            //Debug.Log(posX);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
