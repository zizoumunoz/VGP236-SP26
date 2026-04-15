using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // VARIABLES are pascalCase (lower first letter, upper first letter second and beyond words)
    // CLASSES and FUNCTIONS are Camel
    // PUBLIC VARIABLES and FUNCTIONS are accessible everywhere
    // PRIVATE VARIABLES and FUNCTIONS are only accessible to the class
    // PROTECTED things are available to the current class and its children
    // (OPTIONAL) member variables can be _pascalCase (with an underscore)

    [SerializeField] private GameObject _dropItemPrefab = null;
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private Vector2 _maxRange = Vector2.zero;

    private Vector2 _startingPoint = Vector2.zero;

    private void Awake()
    {
        _startingPoint = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 endPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            endPos.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            endPos.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            endPos.x -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            endPos.x += _speed * Time.deltaTime;
        }
        endPos.x = Mathf.Clamp(endPos.x, _startingPoint.x - _maxRange.x, _startingPoint.x + _maxRange.x);
        endPos.y = Mathf.Clamp(endPos.y, _startingPoint.y - _maxRange.y, _startingPoint.y + _maxRange.y);
        transform.position = endPos;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            float rotate = Random.Range(0.0f, 360.0f);


            Quaternion rotationQuat =  Quaternion.Euler(0.0f, 0.0f, rotate);
            GameObject newDropItem = Instantiate(_dropItemPrefab, transform.position, rotationQuat);
            
        }
    }
}
