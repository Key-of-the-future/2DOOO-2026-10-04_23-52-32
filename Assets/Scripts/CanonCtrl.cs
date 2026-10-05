using UnityEngine;
using UnityEngine.InputSystem;
public class CanonCtrl : MonoBehaviour
{
    public int capacity = 10;
    public int currentBullets = 00;
    public AudioSource BulletSound;
    public AudioSource ReloadSound;
    public Transform spawnPoint;
    public GameObject bullet;
    public InputActionAsset inputActionAsset;
    public float fireRate = 0.5f;
    public float reloadRate = 1f;
    public TMPro.TMP_Text bulletText;
    public TMPro.TMP_Text bulletTotalText;

    private InputActionMap _inputActionMap;
    private InputAction _fire;
    private InputAction _reload;
    private float _nextFireTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputActionMap = inputActionAsset.FindActionMap("Player");
        _fire = _inputActionMap.FindAction("Jump");
        _reload = _inputActionMap.FindAction("Crouch");

        currentBullets = capacity;

         bulletText.text = currentBullets.ToString();
        bulletTotalText.text = capacity + " / " + currentBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fire.triggered && currentBullets > 0 && Time.time >= _nextFireTime)
        {
            Debug.Log("Fire");
            currentBullets--;
             bulletText.text = currentBullets.ToString();
             bulletTotalText.text = capacity + " / " + currentBullets;
            Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
            BulletSound.Play();
            _nextFireTime = Time.time + fireRate;
        }
        if (_reload.triggered)
        {
            Debug.Log("Reload");
            currentBullets = capacity;
            bulletText.text = capacity + " / " + currentBullets;
            bulletTotalText.text = capacity + " / " + currentBullets;
            bulletText.text = currentBullets.ToString();
            _nextFireTime = Time.time + reloadRate;
            ReloadSound.Play();
        }
    }
}
