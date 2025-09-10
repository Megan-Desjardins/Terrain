using UnityEngine;

public class MouvementHelices : MonoBehaviour
{
    //Déclaration de vriables

    public Vector3 vitesseRotation; //Vector(0,0,0 au départ

    public bool moteurEnMarche;//Variable bool par défaut : false

    public float vitesseRotationMax;//1200

    public float accelerationRotation;//10


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Détection de touche
        if(Input.GetKeyDown(KeyCode.Return)){
            moteurEnMarche = !moteurEnMarche; //Inverse de la variable bool, si true -> false et si false -> true

        }


        //Tourner l'hélice
        if(moteurEnMarche == true)//Si le moteur est en marche
        {
                if(vitesseRotation.y < vitesseRotationMax)//Et que la vitesse n'est pas au max
                {
                    vitesseRotation.y += accelerationRotation;//On augmente la vitesse de l'héllice jusqu'au maximum
            }
         }

        if(moteurEnMarche == false)//Si le moteur n'est pas en marche
        {
            if(vitesseRotation.y > 0)//Et que la vitesse de rotation est plus grande que 0 (en marche)
            {
                vitesseRotation.y -= accelerationRotation;//On diminue la vitesse jusqu'à 0
            }
            else//Ou que la vitesse de rotation de l'hélice est déjà à 0
            {
                vitesseRotation = new Vector3(0f,0f,0f);//Garder la vitesse à 0
            }
        }

        transform.Rotate(vitesseRotation * Time.deltaTime);//Tourner l'hélice indépendamment du nb de FPS (pour fonctionner sur des ordis nuls et bons)


    }
}
