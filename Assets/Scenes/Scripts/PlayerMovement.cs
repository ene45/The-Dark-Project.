using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public new Transform camera;
    private Animator animator;
    private float count; //contador para golpear

    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoMovimiento;
    [SerializeField] private float radio;
    public float Life;
    public float MaxLife = 100;

    [Header("Rodar")]
    private bool rodar = true;
    private float gravity = -11.8f;

    public Transform checkGround;
    public Transform spawnParticulasRodar;

    public Vector3 turn;
    private Vector3 playerVelocity;

    [SerializeField] private LayerMask Ground;

    [SerializeField] private GameObject prefabGranada, espada;
    [SerializeField] private Transform spawnGranada;

    bool move = true;

    public boss boss;
    public float RollSpeed;

    public GameObject rodarParticulas;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Life = MaxLife;
    }

    private void Update()
    {
        count = count + 1 * Time.deltaTime;
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0f;

        RaycastHit hit;
        Debug.DrawRay(checkGround.position, Vector3.down, Color.red);

        if (Physics.Raycast(checkGround.position, Vector3.down, out hit, Ground.value))
        {
            if (hit.distance > 0.1f)
            {
                playerVelocity.y += gravity * Time.deltaTime;
            }
        }

        if (move)
        {
            if (hor != 0 || ver != 0)
            {
                Vector3 forward = camera.forward;
                forward.y = 0;
                forward.Normalize();

                Vector3 right = camera.right;
                right.y = 0;
                forward.Normalize();

                Vector3 direction = forward * ver + right * hor;
                movementSpeed = Mathf.Clamp01(direction.magnitude);
                direction.Normalize();

                movement = direction * velocidadDeMovimiento * movementSpeed * Time.deltaTime;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), suavizadoMovimiento);


                Rodar();
            }
            characterController.Move(playerVelocity * Time.deltaTime);
            characterController.Move(movement);



            animator.SetFloat("Speed", movementSpeed);
        }


        Atack();

        /*
        if(Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Granada");
        }
        */

        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }

        PlayerGameOver();

    }
    public void SpawnGranada()
    {
        Instantiate(prefabGranada, spawnGranada.position, spawnGranada.rotation);
    }
    public void ApagarEspada()
    {
        espada.SetActive(false);
    }
    public void ActivarEspada()
    {
        espada.SetActive(true);
    }

    public void ActivarMov()
    {
        move = true;
    }

    public void DesactivarMov()
    {
        move = false;
    }

    public void ParticulasRodar()
    {
        Instantiate(rodarParticulas, spawnParticulasRodar.position, spawnParticulasRodar.rotation);
    }

    //PARA DETECTAR EL ATAQUE DEL BOSS
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("ReciveAttack"))
        {
            print("damage");
            Life -= 10;
        }
    }

    private void Rodar()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && rodar)
        {
            animator.SetTrigger("Rodar");
            rodar = false;
            StartCoroutine(TiempoRodar());
        }

        IEnumerator TiempoRodar()
        {
            Debug.Log("Entre");
            yield return new WaitForSeconds(0.5f);
            rodar = true;
        }

    }

    private void Atack()
    {

        if (Input.GetButtonDown("Fire1") && count > 1)
        {
            animator.SetTrigger("Ataque");
            count = 0;
        }
    }

    private void PlayerGameOver()
    {
        if (Life <= 0)
        {
            print("moriste terriblemente");
        }
    }
}
