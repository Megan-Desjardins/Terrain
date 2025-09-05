using UnityEngine;

public class CameraFixe : MonoBehaviour
{
    //D�CLARATION DE VARIABLES
    //S�lectionner juste les proprit�es de transform de l'objet au lieu de tout l'objet permet d'optimiser
    [SerializeField] private Transform CibleASuivre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SUIVRE LE CUBE
        //La fonction LookAt permet de diriger l'axe des y vers l'objet point�
        transform.LookAt(CibleASuivre);
    }
}
