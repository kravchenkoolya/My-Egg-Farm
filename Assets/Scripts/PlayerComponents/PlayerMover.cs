using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerComponents
{
    public class PlayerMover:MonoBehaviour
    {

        [SerializeField] private float _speed;

        private void Update()
        {
            float x;
            Vector3 mousePos =Camera.main.ScreenToWorldPoint( Mouse.current.position.value);
            if (Touchscreen.current?.touches.Count > 0)
            {
                mousePos =Camera.main.ScreenToWorldPoint( Touchscreen.current.touches[0].position.value);
            }
            x =mousePos.x;

            if (x > transform.position.x)
            {
                transform.localScale=Vector3.one;
            }
            else
            {
                transform.localScale=new Vector3(-1,1,1);
            }
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(x, transform.position.y, transform.position.z),_speed*Time.deltaTime);
        }
    }
}