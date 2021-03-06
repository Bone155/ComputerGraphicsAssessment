﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyShader : MonoBehaviour
{
    public Button button;
    public Renderer renderer;
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
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("ShaderObject"))
                isInFront = true;
        }
        return isInFront;
    }

    public void changeMaterials()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            renderer.material = hit.transform.gameObject.GetComponent<MeshRenderer>().material;
        }
    }

}
