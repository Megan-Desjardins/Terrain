using UnityEngine;

public class MouvementHelices : MonoBehaviour
{
    //DÉCLARATION DE VARIABLES
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
         //DÉTECTION DE TOUCHE
        if(Input.GetKeyDown(KeyCode.Return)){
            moteurEnMarche = !moteurEnMarche; //Inverse de la variable bool, si true -> false et si false -> true

        }


        //TOURNER L'HÉLICE
        //Si le moteur est en marche, on augmente la vitesse de l'héllice jusqu'au maximum
        if(moteurEnMarche == true)
            {
                if(vitesseRotation.y < vitesseRotationMax)
                {
                    vitesseRotation.y += accelerationRotation;
                }
            }

        if(moteurEnMarche == false)
        {
            if(vitesseRotation.y >0)
            {
                vitesseRotation.y -= accelerationRotation;
            }
            else
            {
                vitesseRotation = new Vector3(0f,0f,0f);
            }
        }

        transform.Rotate(vitesseRotation * Time.deltaTime);


    }
}
