using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DBRegistrMenu : MonoBehaviour
{
    
    [System.Serializable]
    public class MenuRegistration
    {
        public TMP_Text login, password1, password2, surname, name, patronymic, rights;
    }

    public MenuRegistration registrationWindow;

    [SerializeField] private WebManager webManager;

    public void Register()
    {
        webManager.Registration(registrationWindow.login.text, registrationWindow.password1.text, registrationWindow.password2.text, registrationWindow.surname.text, registrationWindow.name.text, registrationWindow.patronymic.text, registrationWindow.rights.text);
    }

}
