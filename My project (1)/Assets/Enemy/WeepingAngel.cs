using UnityEngine;

public class WeepingAngel : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    private new Camera camera;
    private new Renderer renderer;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        bool isVisible = GeometryUtility.TestPlanesAABB(
            GeometryUtility.CalculateFrustumPlanes(camera),
            renderer.bounds);

        if (!isVisible)
            TryMovingTowardsPlayer();
    }

    private void TryMovingTowardsPlayer()
    {
        if (player == null)
            return;

        //transform.position = player.transform.position - player.transform.forward;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //Vector3 move = transform.right * x + transform.forward * z;
        //controller.Move(move * speed * Time.deltaTime);
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}