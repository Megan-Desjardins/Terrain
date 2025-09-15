using Unity.VisualScripting;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES
    //Vitesse : 
    [SerializeField] private float vitesseTourne;

    [SerializeField] private float vitesseAvant;

    [SerializeField] private float vitesseAvantMax;

    [SerializeField] private float vitesseMonte;

    public GameObject RefHelice;//Hélice avant (afin de l'utiliser comme référence pour savoir si le moteur est en marche)

    private Rigidbody rb;//Physique

    [SerializeField] private Vector3 vitesseRotation;//Vitesse de rotation de l'hélice



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //DÉTECTION DE TOUCHES VERTICAL - HORIZONTAL
        float axeH = Input.GetAxis("Horizontal");// valeur entre -1 et 1
        float axeV = Input.GetAxis("Vertical");

        //Vérifier si le moteur est allumé et vitesse des hélices
        bool moteurEnMarche = RefHelice.GetComponent<MouvementHelices>().moteurEnMarche;//Récupérer la variable bool (si le moteur est en marche ou non)
        vitesseRotation = RefHelice.GetComponent<MouvementHelices>().vitesseRotation;//Récupérer la vitesse de rotation des hélices

 
        //DÉPLACEMENT ET SONS HÉLICO
        if (moteurEnMarche == true)//Si le MOTEUR EN MARCHE
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

            //Audio 
            if(GetComponent<AudioSource>().isPlaying == false)//Si le son ne joue pas
            {
                //print("Augmenter volume");
                InvokeRepeating("AjustementVolume", 0.1f, 0.05f);
                //Jouer le son
                GetComponent<AudioSource>().Play();
            }


        }
        else//Si le moteur PAS EN MARCHE
        {
            rb.useGravity = true;//Activer la gravité et empêcher de bouger
            //print("Diminuer volume");
            InvokeRepeating("AjustementVolume", 0.1f, 0.05f);
        }


    }

    //FONCTION AJUSTEMENTVOLUME
    void AjustementVolume()
    {
        //On ajuste le volume selon la vitesse rotation des hélices (/1200 car le volume max = 1 et la vitesse max hélices = 1200)
        GetComponent<AudioSource>().volume = vitesseRotation.y / 1200f;
        //On ajuste le pitch selon la vitesse rotation des hélices (0.5f pour commence à 0.5 et /2400 car le pitch doit arriver à 1 en même temps que le volume 
        //mais vue qu'il commence à 0.5, il doit augmenter moins vite (multiplier par un plus gros nb)
        GetComponent<AudioSource>().pitch = 0.5f + (vitesseRotation.y / (2400f));

        //Optimisation -> Stopper tous les invoke (si on veut juste en cancel 1 on met la fonction dans les () )
        if (GetComponent<AudioSource>().volume >= 1)
        {
            //print("Fin du invoke du volume");
            CancelInvoke();
        }
    }


}