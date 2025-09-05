using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
    //Il faut que l'hélico avance/recule progressivement et monte/descend selon une fraction de la vitesse à laquelle il avance et il ne doit pas
    //dépasser la vitesse max. Il doit pouvoir avancer seulement si le moteur est en marche (ref à l'autre script). Voir comment utiliser RelativeTorque
    //car on doit l'utiliser pour faire avancer et monter (syntaxe).

    //DÉCLARATION DE VARIABLES
    [SerializeField] GameObject refHéliceAvant;

    [SerializeField] float vitesseAvant;

    [SerializeField] float vitesseAvantMax;

    [SerializeField] float vitesseTourne;

    [SerializeField] float vitesseMonte;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Faire une variable pour utiliser le Rigidbody plus rapidement
        rb = GetComponent<Rigidbody>();

        refHéliceAvant.moteurEnMarche = false;
        Debug.Log(refHéliceAvant.moteurEnMarche);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float axeH = Input.GetAxis("Horizontal");//Rotation, valeur entre -1 et 1
        float axeV = Input.GetAxis("Vertical");//Monter/descendre

        rb.AddRelativeTorque(0f, axeH * vitesseTourne, 0f);
        Avancer();
        //rb.AddRelativeForce(0f, (axeH * vitesseAvant) * (0.5 * (axeH * vitesseMonte)), 0f);
    }

    private void Avancer(){
        //Augmenter la vitesse si on appuie sur E
        if(Input.GetKeyDown(KeyCode.E)){
            vitesseAvant ++;
        }

        //Maintenir la vitesse à la vitesse max
        if(vitesseAvant == vitesseAvantMax){
            vitesseAvant = vitesseAvantMax;
        }

        //Diminuer la vitesse jusqu'à 0
        if(Input.GetKeyDown(KeyCode.Q)){
            vitesseAvant --;
        }
    }
}
