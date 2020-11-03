using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombArea : MonoBehaviour
{
    public Button button;
    public GameObject testBomb;
    public Transform testSite;
    public float offsetY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (objectInFront())
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    bool objectInFront()
    {
        bool isInFront = false;
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.collider.gameObject.CompareTag("Console"))
            {
                isInFront = true;
            }
            
        }
        return isInFront;
    }

    public void resetTest()
    {
        Instantiate(testBomb, new Vector3(testSite.position.x, testSite.position.y + 1f, testSite.position.z), Quaternion.identity);
    }

}
