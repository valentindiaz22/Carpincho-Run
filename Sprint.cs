using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Dust;
    bool Canjump;
    float timer;
    [SerializeField] private bool Speed;
    [SerializeField] private GameObject menuMuerte;
    [SerializeField] private GameObject ContadorMate;
    [SerializeField] private float velocidad;
    [SerializeField] private bool puedeCorrer;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private AudioSource saltar;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource correr;
    private bool corriendo;
    private bool caminar;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        corriendo = false;
        caminar = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().SetBool("puedecorrer", puedeCorrer);
        timer += Time.deltaTime; 
        gameObject.GetComponent<Animator>().SetFloat("velocidadY",gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKey("left")) {
            gameObject.GetComponent<Animator>().SetBool("corriendo", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);;
            if (Time.timeScale != 0f){
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (timer >= 2f){
                trailRenderer.emitting = false;
            }
        }

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("corriendo", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            if (Time.timeScale != 0f){
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (timer >= 2f){
                trailRenderer.emitting = false;
            }

        }
        if (Speed = true){
            if (Input.GetKey("right") && (Input.GetKey("left shift")) && Canjump)
            {
                corriendo = true;
                gameObject.GetComponent<Animator>().SetBool("corriendo", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * velocidad * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                trailRenderer.emitting = true;
                if (Time.timeScale != 0f){
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }

             if (Input.GetKey("left") && (Input.GetKey("left shift")) && Canjump)
            {
                corriendo = true;
                gameObject.GetComponent<Animator>().SetBool("corriendo", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * velocidad * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                trailRenderer.emitting = true;
                if (Time.timeScale != 0f){
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }

        if (timer >= 2f &&(!Input.GetKey("right") || !Input.GetKey("left")))
        {
            if (Time.timeScale != 0f){
            timer = 0;
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("corriendo", false);
            }

        }

        if (Input.GetKeyDown("up") && Canjump)
        {
            saltar.Play();
            createDust();
            Canjump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1200f));
            gameObject.GetComponent<Animator>().SetBool("aire", !Canjump);
        }
        if ((gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 && Canjump) && caminar)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }


        if ((gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 && Canjump) && corriendo)
        {
            if (!correr.isPlaying)
            {
                caminar = false;
                correr.Play();
            }
        }
        else
        {
            correr.Stop();
            corriendo = false;
            caminar = true;
}

    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground"){
            Canjump = true;
            gameObject.GetComponent<Animator>().SetBool("aire", false);
        }
        if (collision.transform.tag == "yaca"){
            Time.timeScale = 0f;
            menuMuerte.SetActive(true);
            ContadorMate.SetActive(false);
        }

        if (collision.transform.tag == "agua"){
            gameObject.GetComponent<Animator>().SetBool("agua",true);
        }
    }

        void createDust()
    {
        Dust.Play();
    }
}