using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosahedronCloner : MonoBehaviour
{
    public  GameObject icoPrefab;
    public int cantCopias;
    public float rangoPosicion = 25f;

    // Start is called before the first frame update
    void Start()
    {
        if (icoPrefab)
        {
            for (int i = 0; i < cantCopias; i++)
            {
                
                Vector3 rPos = new Vector3(Random.Range(rangoPosicion,-rangoPosicion),Random.Range(rangoPosicion,-rangoPosicion),Random.Range(rangoPosicion,-rangoPosicion));
                Quaternion rRot = Random.rotation;
                GameObject temp = Instantiate(icoPrefab, rPos, rRot);
                Icosahedron icosahedron = temp.GetComponent<Icosahedron>();
                icosahedron.amountToRotate = Random.Range(-.1f, .1f);
            }    
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
