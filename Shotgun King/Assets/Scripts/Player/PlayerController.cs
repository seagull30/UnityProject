using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    public UnityEvent<GridIndex> TunrOver = new UnityEvent<GridIndex>();

    private PlayerInput _input;
    private PlayerShoter _shoter;
    private PlayerMovement _movement;

    public bool IsDead;

    public GameObject PlayerFigure;
    public GameObject GunFigure;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _shoter = GetComponent<PlayerShoter>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //RotateToMouseDir();
        //Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit _hit;
        //Physics.Raycast(_ray, out _hit, 100f);
        ////Debug.Log(_hit.point);
        //
        //Vector3 mPosition = Input.mousePosition; //���콺 ��ǥ ����????????
        //Vector3 oPosition = transform.position; //���� ������Ʈ ��ǥ ����?????????
        ////ī�޶� �ո鿡�� �ڷ� ���� �ֱ� ������, ���콺 position�� z�� ������ ????????
        ////���� ������Ʈ�� ī�޶���� z���� ���̸� �Է½������ �մϴ�.????????
        //mPosition.z = oPosition.z - Camera.main.transform.position.z;
        ////ȭ���� �ȼ����� ��ȭ�Ǵ� ���콺�� ��ǥ�� ����Ƽ�� ��ǥ�� ��ȭ�� ��� �մϴ�.????????
        ////�׷���, ��ġ�� ã�ư� �� �ְڽ��ϴ�.????????
        //Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        //// Debug.Log(target);
        //Debug.DrawLine(transform.position , Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward), Color.red);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward ));
        
        ////������ ��ũź��Ʈ(arctan, ��ź��Ʈ)�� ���� ������Ʈ�� ��ǥ�� ���콺 ����Ʈ�� ��ǥ��????????
        ////�̿��Ͽ� ������ ���� ��, ���Ϸ�(Euler)ȸ�� �Լ��� ����Ͽ� ���� ������Ʈ�� ȸ����Ű��????????
        ////����, �� ���� �Ÿ����� ���� �� ���Ϸ� ȸ���Լ��� �����ŵ�ϴ�.?????????
        ////�켱 �� ���� �Ÿ��� ����Ͽ�, dy, dx�� ������ �Ӵϴ�.????????
        //float dy = target.y - oPosition.y;
        //float dx = target.x - oPosition.x;
        ////������ ȸ�� �Լ��� 0���� 180 �Ǵ� 0���� -180�� ������ �Է� �޴µ� ���Ͽ�????????
        ////(���� 270�� ���� ���� �Էµ� ���� ���������ϴ�.) ��ũź��Ʈ Atan2()�Լ��� ��� ���� ????????
        ////���� ��(180���� ����(3.141592654...)��)���� ��µǹǷ�????????
        ////���� ���� ������ ��ȭ�ϱ� ���� Rad2Deg�� �����־�� ������ �˴ϴ�.????????
        //float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        ////������ ������ ���Ϸ� ȸ�� �Լ��� �����Ͽ� z���� �������� ���� ������Ʈ�� ȸ����ŵ�ϴ�.????????
        //transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
         
         

        if (_input.Mouse)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (Vector3.Distance(transform.position, hit.point) > 0.1f)
                {
                    if (_shoter.TryShot() && !_movement.isMove)
                    {
                        _shoter.shot(hit.point - transform.position);
                        TunrOver.Invoke(_movement._board.PlayerPos);
                    }
                }
                else
                {
                    if (!_movement.isMove)
                    {
                        _movement.isCanMove(transform, hit.point);
                        _shoter.tryReload();
                        TunrOver.Invoke(_movement._board.PlayerPos);
                    }
                }

            }
        }
    }


    //void RotateToMouseDir()
    //{
    //    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition+Vector3.forward*10f));
    //}


}
