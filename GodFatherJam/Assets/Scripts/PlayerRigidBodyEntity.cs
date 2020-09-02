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

    // Update is called once per frame
    void Update()
    {
        _highSommet = sommet[GetHighSommet()];
    }

    public void Move(float x, float y)
    {
        if (x!=0 || y != 0)
        {
            //_rigidbody.AddForce(movementForce * x, upforce, movementForce * y);
            _rigidbody.AddForceAtPosition(new Vector3(movementForce * x, upforce, movementForce * y), _highSommet.position);
        }
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
