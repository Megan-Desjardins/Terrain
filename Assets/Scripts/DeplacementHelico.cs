using Unity.VisualScripting;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    //Déclaration de variables
    //Vitesse : 
    [SerializeField] private float vitesseTourne;

    [SerializeField] private float vitesseAvant;

    [SerializeField] private float vitesseAvantMax;

    [SerializeField] private float vitesseMonte;

    public GameObject RefHelice;//Hélice avant (afin de l'utiliser comme référence pour savoir si le moteur est en marche)

    private Rigidbody rb;//Physique

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Détection de touches
        float axeH = Input.GetAxis("Horizontal");// valeur entre -1 et 1
        float axeV = Input.GetAxis("Vertical");

        //Vérifier si le moteur est allumé
        bool moteurEnMarche = RefHelice.GetComponent<MouvementHelices>().moteurEnMarche;//Récupérer la variables

 
        //Déplacement de l'hélico
        if (moteurEnMarche == true)//Si le moteur est en marche
        {
            rb.useGravity = false;//Désactiver la gravité

            //Vitesse avant
            if (vitesseAvant < vitesseAvantMax)//Si vitesse avant est plus petite que la vitesse max
            {
                vitesseAvant += 10f;//Augmenter la vitesse par bon de 10
            }
            else
            {
                if (vitesseAvant >= vitesseAvantMax)//Si la vitesse est au max
                {
                    vitesseAvant = vitesseAvantMax;//Garder la vitesse à 10000
                }
            }

            //Vitesse monte
            vitesseMonte = 0.5f * vitesseAvant;//0.5 fois plus que la vitesse avant

            //Rotation de l'hélico Y
            rb.AddRelativeTorque(0f, axeH * vitesseTourne, 0f);

            //Déplacement de l'hélico Y et Z
            rb.AddRelativeForce(0f, axeV * vitesseMonte, axeV * vitesseAvant);
        }
        else//Si le moteur n'est pas en marche
        {
            rb.useGravity = true;//Activer la gravité et empêcher de bouger
        }


    }


}