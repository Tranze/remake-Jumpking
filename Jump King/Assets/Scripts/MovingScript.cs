using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class MovingScript : MonoBehaviour, IDataPersistence
{
    private bool isMoving = false;
    [SerializeField] private GameObject[] targets;
    [SerializeField] private float objectSpeed;

    private int targetIndex = 0;
    private GameObject nextPos;
    private Animator anim;
    void Awake() {

        isMoving = false;  // Set isMoving to false to prevent unnecessary updates
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Debug.Log(isMoving);
    }

    // Detect trigger with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If we triggered the player, enable isMoving and show indicator
        if (other.CompareTag("Player"))
        {
            anim.SetInteger("state",1);
            isMoving = true;
            Debug.Log("Collided with player");
        }
    }

    void Update()
    {
        if(isMoving == true)
        {
            isMovingGameObject();
        }
    }

    void isMovingGameObject()
    {
        if (Vector2.Distance(targets[targetIndex].transform.position, transform.position) < 0.1f)
        {
            targetIndex++;
            if (targetIndex >= targets.Length)
            {
                targetIndex = 0;
            }
            nextPos = targets[targetIndex];
            isMoving = false;
            anim.SetInteger("state",0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[targetIndex].transform.position, objectSpeed * Time.deltaTime);
        }
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.ravenPosition;
        if(transform.position.Equals(Vector3.zero))
        {
            this.transform.position = new Vector3(228.4353f, 13.4767f, 0.0f);
        }
        this.isMoving = data.isMoving;
        this.targetIndex = data.targetIndex;
        Debug.Log(isMoving);
    }

    public void SaveData(ref GameData data)
    {
        data.ravenPosition = this.transform.position ;
        data.isMoving = this.isMoving ;
        data.targetIndex = this.targetIndex;
    }
}
