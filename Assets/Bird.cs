using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] private float launchPower = 250;
    private bool launched;
    private float notMoving;

    private void Awake()
    {
        initialPosition = transform.position;
       

    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if (launched == true && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            notMoving += Time.deltaTime;
        }

        if (transform.position.y > 20 ||
            transform.position.y < -10 ||
            transform.position.x > 20 ||
            transform.position.x < -30||
            notMoving > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        launched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

}
