using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
public class Bender : MonoBehaviour
{
    public Icosahedron icosahedron;
    public float smooth = 1f;

    public bool invert;
    // private Vector3 initialRotation;
    // private Vector3 newRotation;
    
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        FindIcosahedron(transform.parent);
    }

    private void FindIcosahedron(Transform parent)
    {
        if (parent.GetComponent<Icosahedron>())
        {
            icosahedron = parent.GetComponent<Icosahedron>();
        }
        else
        {
            FindIcosahedron(parent.parent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (icosahedron)
        {
            
            // newRotation = initialRotation + icosahedron.rotacion;
            // // transform.eulerAngles = newRotation;
            // transform.localRotation = Quaternion.Euler(newRotation);
            float dir = invert ? 1 : -1;
            transform.Rotate(icosahedron.amountToRotate * dir, 0, 0, Space.Self);
            //transform.rotation = initialRotation * Quaternion.Euler(0f, 45f, 0f);

            // newRotation = initialRotation;
            // newRotation.x += icosahedron.angulo;
            // transform.localEulerAngles = newRotation;
        }
    }

    [Button]
    public void MyLocalAngle()
    {
        Debug.Log("transform.rotation " + transform.rotation);
        Debug.Log("transform.localRotation " + transform.localRotation);
        Debug.Log("transform.eulerAngles " + transform.eulerAngles);
        Debug.Log("transform.eulerAngles " + transform.localEulerAngles);
        
        Debug.Log("---------------------------------" );
        
    }
}
