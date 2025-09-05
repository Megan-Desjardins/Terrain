using UnityEngine;

public class CameraDistanceConstante : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES
    [SerializeField] private GameObject CibleASuivre;

    [SerializeField] private Vector3 Distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SUIVRE LA CIBLE
        //Suivre la position de l'objet avec la caméra selon une certaine distance
        transform.position = CibleASuivre.transform.position + Distance;
        transform.LookAt(CibleASuivre.transform);
    }
}
