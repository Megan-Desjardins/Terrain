using Unity.VisualScripting;
using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    /// DÉCLARATION DE VARIABLES ///
    //Vitesse : 
    [SerializeField] private float vitesseTourne;

    [SerializeField] private float vitesseAvant;

    [SerializeField] private float vitesseAvantMax;

    [SerializeField] private float vitesseMonte;

    public GameObject RefHelice;//Hélice avant 
    //(afin de l'utiliser comme référence pour savoir si le moteur est en marche)

    private Rigidbody rb;//Physique

    [SerializeField] private Vector3 vitesseRotation;//Vitesse de rotation de l'hélice

    [SerializeField] private bool finJeu;//Savoir si jeu finit ou pas (gamover)

    [SerializeField] private GameObject fxExplosion;//Effet d'explosion (quand touche hélico terrain)



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Détection de touches
        float axeH = Input.GetAxis("Horizontal");// valeur entre -1 et 1
        float axeV = Input.GetAxis("Vertical");

        //Vérifier si le moteur est allumé et vitesse des hélices
        bool moteurEnMarche = RefHelice.GetComponent<MouvementHelices>().moteurEnMarche;
        //Récupérer la variable bool (si le moteur est en marche ou non)
        vitesseRotation = RefHelice.GetComponent<MouvementHelices>().vitesseRotation;
        //Récupérer la vitesse de rotation des hélices

 
        /// DÉPLACEMENT HÉLICO ///
        if (moteurEnMarche == true)//Si le moteur est EN MARCHE
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
            vitesseMonte = 0.2f * vitesseAvant;//0.5 fois plus que la vitesse avant

            //Rotation de l'hélico Y
            rb.AddRelativeTorque(0f, axeH * vitesseTourne, 0f);

            //Déplacement de l'hélico Y et Z
            rb.AddRelativeForce(0f, axeV * vitesseMonte, axeV * vitesseAvant);

            //Audio 
            if(GetComponent<AudioSource>().isPlaying == false)//Si le son ne joue pas
            {
                //print("Jouer le son");
                InvokeRepeating("AjustementVolume", 0.1f, 0.1f);
            }


        }
        else//Si le moteur n'est PAS EN MARCHE
        {
            rb.useGravity = true;//Activer la gravité et empêcher de bouger
        }


    }

    /// FONCTION AJUSTER VOLUME ///
    void AjustementVolume()
    {
        GetComponent<AudioSource>().volume = vitesseRotation.y / 1200f;//On augmente/diminue le volume selon la vitesse 
        //de rotation des hélices (divisée par 1200 car le volume max est 1 et la vitesse max des hélices est 1200)

        //Optimisation -> Stopper tous les invoke et si on veut juste en cancel 1 on met la fonction dans les ()
        if(GetComponent<AudioSource>().volume >= 1)
        {
            //print("Fin du invoke du volume");
            CancelInvoke();
        }
    }

    /// COLLISIONS ///
    void OnCollisionEnter(Collision infosCollision)
    {
        if(infosCollision.gameObject.name == "Terrain"){

            //Debug.Log("Collision terrain");
            fxExplosion.SetActive(true);
        }
    }


}