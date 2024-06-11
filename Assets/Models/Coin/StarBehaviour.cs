using System;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    public GameObject go;
    public AudioSource ass;
    Boolean stop = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && stop)
        {
            stop = false;
            ass.Play(1);
            Destroy(gameObject, 3);
            Destroy(go);
            Debug.Log("Mondongo");

            mujer sol = new mujer();
        }
    }
    
}
public class mujer : MonoBehaviour { }