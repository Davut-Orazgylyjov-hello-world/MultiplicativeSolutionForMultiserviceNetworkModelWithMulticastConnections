using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInformation : MonoBehaviour
{
    public static NetworkInformation netInfo;

    public int l;
    public int s;

    private NetworkManager _netManager;

    private string _wayToUsers;


    private void Awake()
    {
        netInfo = this;
    }

    private void Start()
    {
        _netManager = NetworkManager.networkManager;
    }

    public void SetL(int num)
    {
        l = num;
        HUD.hud.SetHUD($"L = [{num}]", TypeHUD.L);
    }

    public void SetS(int num)
    {
        s = num;
        HUD.hud.SetHUD($"S = [{num}]", TypeHUD.S);
    }

    public void GetAllPhysicalPathsNetwork()
    {
        StartCoroutine(DelayGetAllPhysicalPathsNetwork());
    }

    private IEnumerator DelayGetAllPhysicalPathsNetwork()
    {
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < _netManager.sourceInformation.Length; i++)
        {
            if (_netManager.sourceInformation[i] == null)
                break;

            Connection conMother = _netManager.sourceInformation[i].GetMotherConnectionSourceInformation();
            CheckConnectionsMother(conMother);
        }
    }

    private void CheckConnectionsMother(Connection conMother)
    {
        //check all connections to mother
        for (int i = 0; i < conMother.connections.Length; i++)
        {
            if (conMother.connections[i] == null)
                break;
            
            SaveWay(conMother.networkConnections[i].nameNetworkConnection);

            if (conMother != conMother.connections[i])
            {
                SaveWay(conMother.connections[i].networkConnections[i].nameNetworkConnection);
                
                Connection nextCon = RecursiveConnections(conMother, conMother.connections[i]);

                if (conMother != nextCon)
                {

                    for (int j = 0; j < nextCon.users.Length; j++)
                    {
                        if (nextCon.users[j] == null)
                            break;

                        SetWay();
                     
                        Debug.Log(nextCon.users[j].nameUser);
                    }
                }
            }
        }
    }

    private Connection RecursiveConnections(Connection conMother, Connection currentConnection)
    {

        //check have we there users
        for (int i = 0; i < currentConnection.users.Length; i++)
        {
            if (currentConnection.users[i] == null)
                break;
            
            return currentConnection;
        }

        for (int i = 0; i < currentConnection.connections.Length; i++)
        { 
            Connection nextConnection = RecursiveConnections(conMother,currentConnection.connections[i]);
           // if(nextConnection.users)
           
           SaveWay(nextConnection.networkConnections[i].nameNetworkConnection);
        }

        ResumeWay();
        return conMother;
    }

    private void SaveWay(string way)
    {
        _wayToUsers += way+",";
    }

    private void SetWay()
    {
        Debug.Log(_wayToUsers);
        ResumeWay();
    }

    private void ResumeWay()
    {
        _wayToUsers = null;
    }
}
