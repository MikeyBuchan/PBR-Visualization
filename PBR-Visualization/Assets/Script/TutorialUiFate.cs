using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUiFate : MonoBehaviour
{
    public GameObject panelTutUi;
    public GameObject textTutUi;

    GameObject playerHolder;
    public float fadeDis;

    float dis;

    public Vector2 vector;
    Color colorHolder;

    void Start()
    {
        playerHolder = GameObject.FindWithTag("Player");   
    }

    private void Update()
    {
        DistanceCalculator();
        AdjustUI();
        LookToPlayer();
    }

    void LookToPlayer()
    {
        transform.LookAt(GameObject.FindWithTag("Player").transform);
    }

    void DistanceCalculator()
    {
        dis = Vector3.Distance(transform.position, playerHolder.transform.position);
    }

    void AdjustUI()
    {
        float value = 0;
        if (dis < vector.y && dis > vector.x)
        {
            value = 1;
        }
        else
        {
            float distancex = Mathf.Abs(dis - vector.x);
            float distancey = Mathf.Abs(dis - vector.y);
            if (distancex > distancey)
                value = (1f / fadeDis * distancey) * -1 + 1;
            else
                value = (1f / fadeDis * distancey) * -1 + 4.5f;
            Debug.Log(value = (1f / fadeDis * distancey) * -1 + 4.5f);
        }
        colorHolder = panelTutUi.GetComponent<Image>().color;
        colorHolder.a = value;
        panelTutUi.GetComponent<Image>().color = colorHolder;

        colorHolder = textTutUi.GetComponent<Text>().color;
        colorHolder.a = value;
        textTutUi.GetComponent<Text>().color = colorHolder;
    }
}
