using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos=transform.position;
        _spriteRenderer=GetComponent<SpriteRenderer>();
    }
    /*void FixedUpdate() // 50 fps 50 kere çalýþýyor
    {
        r2d.velocity = new Vector2(speed, 0.0f);//x ve y componenti x ile ilerleyecek

    }*/
    void Update()  //per frame 90 kere çalýþýyor
    {

        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);//speedim 1 olunca çalýþacak bu kod yani
        transform.position = charPos;

        if (Input.GetAxis("Horizontal")==0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal")<  -0.1f)
            {
            _spriteRenderer.flipX = true;
        }

    }
    void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z-1.0f);// kameram direkt heromun üstünde olmamasý için
    }
}
