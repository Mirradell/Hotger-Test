using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSphereScript : MonoBehaviour
{
    public GameObject upButton;
    public float speedX;
    public float speedY;
    public int cameraDistance;
    public bool isMovingUp;
    public float speedYPlus;

    public float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        isMovingUp = false;
        nextTime = Time.time + 15f;
        speedX = ScenesDataStaticScript.speed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speedX, speedY * (isMovingUp ? 1 : -1)) * Time.deltaTime;
        Camera.main.transform.position = new Vector3(this.transform.position.x, 0, -cameraDistance);
        upButton.transform.position += new Vector3(speedX, 0) * Time.deltaTime;

        if (Time.time >= nextTime)
        {
            speedY += speedYPlus;
            nextTime = Time.time + 15f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            ScenesDataStaticScript.timeFromStart = Time.timeSinceLevelLoad;
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndGame");
            //Destroy(this.gameObject);
        }
    }
}
