using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    //游戏玩家可用资源管理
    private static DataManager dataManager => DataManager.Instance;

    //当前选择的炮塔
    public TurretData selectedTurret;

    //金钱动画组建
    public Animator moneyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                //开始创建炮塔
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit,100000,LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    Mapcube mapCube = hit.collider.GetComponent<Mapcube>();
                    if(mapCube.turretNow == null)
                    {
                        if(dataManager.money > selectedTurret.cost)
                        {
                            
                            //可以创建
                            dataManager.ChangeMoney(-selectedTurret.cost);
                            mapCube.BuildTurret(selectedTurret.turretPrefab);
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("MoneyAnimation");
                        }

                    }
                    else
                    {
                        //升级该炮塔
                    }
                }
            }
        }
    }

    public void SelectLaserTurret(bool isOn)
    {
        if (isOn)
        {
            selectedTurret = laserTurretData;
        }
    }

    public void SelectMissileTurret(bool isOn)
    {
        if (isOn)
        {
            selectedTurret = missileTurretData;
        }
    }
    public void SelectStandardTurret(bool isOn)
    {
        if (isOn)
        {
            selectedTurret = standardTurretData;
        }
    }

}
