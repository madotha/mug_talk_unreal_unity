using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    protected Joystick joystick;
    protected Joybutton joybutton;

    private new Rigidbody rigidbody;

    public float joySpeed = 10f;
    public float jumpForce = 70f;
    public bool isGrounded = true;
    public bool isFinished = false;

    // Bei "Erwachen" der Klasse wird geprüft,
    // dass PlayerMovement wirklich instanziert wird
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    // Findet alle benötigten Objekte
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();

        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Wird für die Sprungmechanik verwendet
        if (collision.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Wenn das Spiel beendet ist, wird der Player immobil
        if (GameControl.instance.gameFinished == false) {

            // Moves the Object in the given Joystick direction
            rigidbody.velocity = new Vector3(joystick.Horizontal * joySpeed,
                                                rigidbody.velocity.y,
                                                    rigidbody.velocity.z);

            // Schleifen zur Überprüfung der Sprungmechanik
            if (joybutton.Pressed && isGrounded)
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                joybutton.Pressed = false;
            }

            if (!joybutton.Pressed && !isGrounded)
            {
                isGrounded = false;
                joybutton.Pressed = false;
            }

            if (joybutton.Pressed && !isGrounded)
            {
                isGrounded = false;
                joybutton.Pressed = false;
            }
        }

        // Bei Restart Player wieder mobil machen und zurücksetzen
        if (GameControl.instance.gameFinished == true && joybutton.Pressed)
        {
            GameControl.instance.gameFinished = false;
            RespawnPlayer();
        }
    }

    // Setzt den Spieler an den Ursprungsort zurück
    public void RespawnPlayer()
    {
        gameObject.transform.position = new Vector3(-16.64f, 4f, 0f);
    }

}
