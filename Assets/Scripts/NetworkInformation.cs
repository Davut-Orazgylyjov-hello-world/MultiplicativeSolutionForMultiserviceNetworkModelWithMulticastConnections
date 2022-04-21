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

    public string[] _wayToUsers;
    public string _debugWay;


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
            
            //find network connection
            for (int j = 0; j < conMother.networkConnections.Length; j++)
            {
                if( conMother.networkConnections[i] == conMother.connections[i].networkConnections[j])
                {
                    SaveWay(conMother.connections[i].networkConnections[j].nameNetworkConnection);
                    break;
                }
            }
            
            RecursiveConnections(conMother, conMother.connections[i], conMother);
        }
    }


    private void RecursiveConnections(Connection conMother, Connection currentConnection, Connection conPrevious)
    {
        
     //   SaveWay(currentConnection.networkConnections[].nameNetworkConnection);
        
        //check have we there users
        for (int i = 0; i < currentConnection.users.Length; i++)
        {
            if (currentConnection.users[i] == null)
                break;

            SetWay();
        }

        for (int i = 0; i < currentConnection.connections.Length; i++)
        {
            if (currentConnection.connections[i] == null)
            {
                ResumeWay();
                break;
            }

            for (int j = 0; j < currentConnection.networkConnections.Length; j++)
            {
                if( currentConnection.networkConnections[i] == currentConnection.connections[i].networkConnections[j])
                {
                    if (CanGoToWay(currentConnection.networkConnections[i]))
                    {
                        SaveWay(currentConnection.networkConnections[i].nameNetworkConnection);

                        if (conMother != currentConnection.connections[i] &&
                            currentConnection.connections[i] != conPrevious)
                            RecursiveConnections(conMother, currentConnection.connections[i], currentConnection);

                        break;
                    }
                }
            }
        }
    }

    private bool CanGoToWay(NetworkConnection netCon)
    {
        foreach (var t in _wayToUsers)
        {
            if (netCon.nameNetworkConnection == t)
                return false;
        }

        return true;
    }

    private void SaveWay(string way)
    {
        for (int i = 0; i < _wayToUsers.Length; i++)
        {
            if (_wayToUsers[i] == "")
            {
                _wayToUsers[i] = way;
                _debugWay += _wayToUsers[i];
                break;
            }
        }
    }
    
    private void SetWay()
    {
        Debug.Log(_debugWay);
    }
    
    private void ResumeWay()
    {
        _wayToUsers[_debugWay.Length] = "";
        _debugWay = _debugWay.Remove(_debugWay.Length-1);
    }
}
