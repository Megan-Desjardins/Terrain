using Unity.VisualScripting;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES (private par défaut) ///////////////////
    //Vitesse : 
    [SerializeField] float vitesseTourne;

    [SerializeField] float vitesseAvant;

    [SerializeField] float vitesseAvantMax;

    [SerializeField] float vitesseMonte;

    public GameObject RefHelice;//Hélice avant (afin de l'utiliser comme référence pour savoir si le moteur est en marche)

    private Rigidbody rb;//Physique

    private AudioSource audioSource;//Son

    [SerializeField] Vector3 vitesseRotation;//Vitesse de rotation de l'hélice

    public bool moteurEnMarche;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //DÉTECTION DE TOUCHES VERTICAL - HORIZONTAL ///////////////
        float axeH = Input.GetAxis("Horizontal");// valeur entre -1 et 1
        float axeV = Input.GetAxis("Vertical");

        //Vérifier si le moteur est allumé et vitesse des hélices
        moteurEnMarche = RefHelice.GetComponent<MouvementHelices>().moteurEnMarche;//R�cup�rer la variable bool (si le moteur est en marche ou non)
        vitesseRotation = RefHelice.GetComponent<MouvementHelices>().vitesseRotation;//R�cup�rer la vitesse de rotation des h�lices

 
        //DÉPLACEMENT ET SONS HÉLICO //////////////////////
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
            if(audioSource.isPlaying == false)//Si le son ne joue pas
            {
                //print("Augmenter volume");
                InvokeRepeating("AjustementVolume", 0.1f, 0.05f);
                //Jouer le son
                audioSource.Play();
            }


        }
        else//Si le moteur PAS EN MARCHE
        {
            rb.useGravity = true;//Activer la gravité et empêcher de bouger
            //print("Diminuer volume");
            InvokeRepeating("AjustementVolume", 0.1f, 0.05f);
        }


    }

    //FONCTION AJUSTEMENTVOLUME /////////////  
    void AjustementVolume()
    {
        //On ajuste le volume selon la vitesse rotation des hélices (/1200 car le volume max = 1 et la vitesse max h�lices = 1200)
        audioSource.volume = vitesseRotation.y / 1200f;
        //On ajuste le pitch selon la vitesse rotation des hélices (0.5f pour commence à 0.5 et /2400 car le pitch doit arriver � 1 en m�me temps que le volume 
        //mais vue qu'il commence à 0.5, il doit augmenter moins vite (multiplier par un plus gros nb)
       audioSource.pitch = 0.5f + (vitesseRotation.y / (2400f));

        //Optimisation -> Stopper tous les invoke (si on veut juste en cancel 1 on met la fonction dans les () )
        if (audioSource.volume >= 1)
        {
            //print("Fin du invoke du volume");
            CancelInvoke();
        }
    }

}