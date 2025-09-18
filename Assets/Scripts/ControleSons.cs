using UnityEngine;

public class ControleSons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //Premier para : fonction, Deuxième para : délai avant d'éxecuter - Troisième para : délai avant les autres exécutions
       InvokeRepeating("AjustementVolume", 0.1f, 0.1f);
    }

    void AjustementVolume()
    {
        GetComponent<AudioSource>().volume += 0.05f;

        //Optimisation -> Stopper tous les invoke et si on veut juste en cancel 1 on met la fonction dans les ()
        if(GetComponent<AudioSource>().volume >= 1)
        {
            //print("Fin du invoke du volume");
            CancelInvoke();
        }
    }

    // Update is called once per frame
    void Update()
    {


        //METTRE SUR MUTE ///////////////
        if(Input.GetKeyDown(KeyCode.M))//Détection de touche
        {
            if (!AudioListener.pause)//Si le son n'est pas à pause
            { 
                print("mute");
                AudioListener.pause = true;//Pause
            }
            else//Si le son est à pause
            {
                print("demute");
                AudioListener.pause = false;//Jouer
            }
        }
    }
}
