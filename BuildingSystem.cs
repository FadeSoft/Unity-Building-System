using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public GameObject mainObj;

    RaycastHit hit;
    public Material mat;
    bool x;


    private void Start()
    {
        x = true;
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast, out hit, Mathf.Infinity, (1 << 3)))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + .9f, hit.point.z);
        }
    }

     void Update()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast, out hit, Mathf.Infinity, (1 << 3)))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + .8f, hit.point.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(x)
                Instantiate(mainObj, transform.position, transform.rotation);

        }

        if (Input.GetKey(KeyCode.E))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,90,0), Time.deltaTime * 20);
            transform.Rotate(new Vector3(0,90,0) * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 20);
            transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime, Space.World);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("Ground"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            x = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("Ground"))
        {
            GetComponent<MeshRenderer>().material.color = mat.color;
            x = true;

        }
    }
}
