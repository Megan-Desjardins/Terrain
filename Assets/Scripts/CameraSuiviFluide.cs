using UnityEngine;

public class CameraSuiviFluide : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES
    [SerializeField] GameObject CibleASuivre;// la cible est déterminée dans l'inspecteur

    [SerializeField] Vector3 Distance;

    [SerializeField] float amortissement;

    void FixedUpdate () 
    {

    //SUIVRE LA CIBLE
    //Définie une position 5 mètres en hauteur et 10 mètres en arrière de la cible (selon les axes locaux de la cible)
    Vector3 positionFinale = CibleASuivre.transform.TransformPoint(Distance);  

    //Prochaine position entre la position de départ de la caméra et la position finale désirée selon un facteur 0.5
    //Lerp permet de faire de l'interpolation (images entre images clées), cela faire donc un mouvement de caméra fluide et pas instané
    transform.position = Vector3.Lerp(transform.position, positionFinale, amortissement);

    //Regarde toujours la cible
    transform.LookAt(CibleASuivre.transform);
    }

}
