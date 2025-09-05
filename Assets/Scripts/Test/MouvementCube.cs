using UnityEngine;

public class MouvementCube : MonoBehaviour
{
    //D�CLARATION DE VARIABLES
    [SerializeField] private float vitesseDeplacement;

	[SerializeField] private float vitesseRotation;

    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //D�PLACEMENT
        float axeH = Input.GetAxis("Horizontal");//Valeur entre 1 0 et -1 progressif
        float axeV = Input.GetAxis("Vertical");

        //Je veux faire tourner le rigidbody avec l'axe Horizontal
        rb.AddRelativeTorque(0f, axeH * vitesseRotation, 0f);
        rb.AddRelativeForce(0f, axeV * vitesseDeplacement, 0f);


        //Changer le angular damping (pour que �a s'arr�te)
    }
}
