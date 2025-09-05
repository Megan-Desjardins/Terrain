using UnityEngine;

public class CameraSuiviFluide : MonoBehaviour
{
    //D�CLARATION DE VARIABLES
    [SerializeField] GameObject CibleASuivre;// la cible est d�termin�e dans l'inspecteur

    [SerializeField] Vector3 Distance;

    [SerializeField] float amortissement;

    void FixedUpdate () 
    {

    //SUIVRE LA CIBLE
    //D�finie une position 5 m�tres en hauteur et 10 m�tres en arri�re de la cible (selon les axes locaux de la cible)
    Vector3 positionFinale = CibleASuivre.transform.TransformPoint(Distance);  

    //Prochaine position entre la position de d�part de la cam�ra et la position finale d�sir�e selon un facteur 0.5
    //Lerp permet de faire de l'interpolation (images entre images cl�es), cela faire donc un mouvement de cam�ra fluide et pas instan�
    transform.position = Vector3.Lerp(transform.position, positionFinale, amortissement);

    //Regarde toujours la cible
    transform.LookAt(CibleASuivre.transform);
    }

}
