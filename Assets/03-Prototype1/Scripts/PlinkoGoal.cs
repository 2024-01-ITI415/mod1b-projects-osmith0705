using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlinkoGoal : MonoBehaviour
{
    static int goalCount = 5;
    public GameObject winCanvas;
    public GameObject ball;

    public Material hitMat;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material = hitMat;
        Destroy(this);
        goalCount--;
    }

    void Update()
    {
        if (goalCount == 0)
        {
            winCanvas.SetActive(true);
            Destroy(ball);
            Invoke("loadScene", 5.0f);

        }
    }

    private void loadScene()
    {
        SceneManager.LoadScene("SceneMain");
    }

}
