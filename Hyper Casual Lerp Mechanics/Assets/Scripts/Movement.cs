using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float SwipeSpeed;
    public float MoveSpeed;
    private Camera cam;
    float hor;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        //hor = Input.GetAxis("Horizontal");
        //transform.Translate(new Vector3(hor* MoveSpeed * Time.deltaTime, 0, MoveSpeed * Time.deltaTime));

        transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;
        if (Input.GetKey("Fire1"))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            GameObject character = LerpMechanis.instance.collect[0];
            Vector3 hitVec = hit.point;
            hitVec.y = character.transform.localPosition.y;
            hitVec.z = character.transform.localPosition.z;

            character.transform.localPosition = Vector3.MoveTowards(character.transform.localPosition, hitVec, Time.deltaTime * SwipeSpeed);
        }
    }
}
