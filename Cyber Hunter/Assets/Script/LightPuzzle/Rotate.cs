using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool BisaRotate = false;
    [SerializeField] private Vector3 Rotation;
    [SerializeField] private float RotateSpeed;
    public GameObject Tanda;

    private void Update()
    {
        if(BisaRotate == false)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Rotation = Vector3.up;
            Rotation.z = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Rotation = Vector3.down;
            Rotation.z = -1;
        }
        else
        {
            Rotation = Vector3.zero;
        }

        transform.Rotate(Rotation * RotateSpeed * Time.deltaTime);

    }

    private void OnMouseDown()
    {
        Debug.Log("Masuk");
        BisaRotate = !BisaRotate;
        if(BisaRotate == true)
        {
            Tanda.SetActive(true);
        }
        else
        {
            Tanda.SetActive(false);
        }

    }

}
