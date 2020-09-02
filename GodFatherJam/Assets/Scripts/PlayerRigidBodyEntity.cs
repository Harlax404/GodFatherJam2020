using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBodyEntity : MonoBehaviour
{
    #region Variables
    private Rigidbody _rigidbody;
    private GameManager _gm;
    public float movementForce = 15f;
    public float upforce = 10f;

    private float xdir = 0f;
    private float ydir = 0f;

    public Transform[] sommet;
    private Transform _highSommet;
    #endregion

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Instance;
    }

    
    void FixedUpdate()
    {
        _highSommet = sommet[GetHighSommet()];
        if (Mathf.Abs(xdir) > 0.1f || Mathf.Abs(ydir) > 0.1f)
        {
            _rigidbody.AddForceAtPosition(new Vector3(movementForce * xdir, upforce, movementForce * ydir), _highSommet.position);
        }
    }

    public void Move(float x, float y)
    {
        xdir = x;
        ydir = y;
    }

    int GetHighSommet()
    {
        int _high = 0;
        for (int i=0; i<4; i++)
        {
            if (sommet[i].position.y > sommet[_high].position.y)
            {
                _high = i;
            }
        }
        return _high;
    }
}
