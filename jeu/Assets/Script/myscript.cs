using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bonjour");
        int Addition(int num1, int num2)
        {
            return num1 + num2;
        }
        int sum = Addition(4, 3);
        Debug.Log("Résultat somme : " + sum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
