using UnityEngine;
using UnityEngine.InputSystem;
public class CanonCtrl1 : MonoBehaviour
{
    public int capacity = 10;
    public int currentBullets = 00;
    public AudioSource BulletSound;
    public Transform spawnPoint;
    public GameObject bullet;
    public InputActionAsset inputActionAsset;
    private InputActionMap _inputActionMap;
    private InputAction _fire;

    private InputAction _reload;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputActionMap = inputActionAsset.FindActionMap("Player");
        _fire = _inputActionMap.FindAction("Jump");
        _reload = _inputActionMap.FindAction("Interact");

        currentBullets = capacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fire.triggered && currentBullets > 0)
        {
            Debug.Log("Fire");
            currentBullets--;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            BulletSound.Play();
        }
        if (_reload.triggered)
        {
            Debug.Log("Reload");
            currentBullets = capacity;
        }
    }
}
