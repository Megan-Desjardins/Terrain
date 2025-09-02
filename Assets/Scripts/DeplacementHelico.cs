using UnityEngine;

public class DeplacementHelico : MonoBehaviour
{
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
        float axeH = Input.GetAxis("Horizontal");//Valeur entre 1 0 et -1 progressif
        float axeV = Input.GetAxis("Vertical");

        //Tourner le rigidbody avec l'axe Horizontal
        rb.AddRelativeTorque(0f, axeH * vitesseRotation, 0f);

        //Tourner le rigidbody avec l'axe vertical
        rb.AddRelativeForce(0f, axeV * vitesseDeplacement, 0f);

    }
}
