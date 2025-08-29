using UnityEngine;
// Fonctionnalité multijoueur : using UnityNetcode;

public class TourneObjet : MonoBehaviour
{
    //Déclarer publiquement la variable permet de la modifier pour différent objets avec le même script
    public Vector3 valeurRotation; //Vector(0,0,0)

    public bool moteurEnMarche;//Variable bool par défaut : false
    public float vitesseRotationMax;

    /*Si le moteur est en marche, l'objet tourne
    * Si le moteur n'est pas en marche l'objet ne tourne pas
    * La touche Return du clavier me permet de démarrer ou d'arrêter le moteur*/

    // Start appeler lorsqu'on clique sur play
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        /*//Calcule à chaque update (cela permet de calculer par exemple la vie d'un joueur)
        print (resultat);*/

        //DÉTECTION DE TOUCHE
        if(Input.GetKeyDown(KeyCode.Return)){
            moteurEnMarche = !moteurEnMarche; //Inverse de la variable bool, si true -> false et si false -> true

        }

        //transform.Rotate(valeurRotation);//Dépendance au framerate
        //*Time permet d'enlever la dépendance au frames(même vitesse pour les joueurs avec un bon ordi ou mauvais)
        //Rotation de l'objet seulement si le moteur est en marche
        if(moteurEnMarche == true && vitesseRotationMax < 500)
            {
                transform.Rotate(valeurRotation * vitesseRotationMax++ * Time.deltaTime);
            }else{
                if(moteurEnMarche == true && vitesseRotationMax >= 500){
                    transform.Rotate(valeurRotation * 500 * Time.deltaTime);
                }
            }
        
        if(moteurEnMarche == false && vitesseRotationMax >= 500){
            transform.Rotate(valeurRotation * vitesseRotationMax-- * Time.deltaTime); //Remettre vitessemax à 0 ici
        }


    }

}



    /***** RÉVISION
    Public : variable publique, Private ou rien : variable locale * Minitest
    public int resultat;
    public float unFloat;
    public string laChaine;
    public GameObject objet;

    //Serialize permet de voir une variable privée dans l'inspecteur (sans avoir à la mettre public)
    [SerializeField] private int resultatPriveeVisible;*/

    /*//La fonction fait un clacul va exécuter le calcul avec les paramètre ci-dessous (cela permet d'alléger
        // le code et de ne pas avoir a réécrire le calcul à chaque fois)
        resultat = FaitUnCalcul(5, 6);
        print (resultat);*/

    /*//Premier mot avant une fonction représente le type de valeur qu'elle retourne (si non -> void)
    int FaitUnCalcul(int a, int b){
        return a + b;
    }*/