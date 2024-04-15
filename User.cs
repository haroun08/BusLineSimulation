
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User : Object
{

    private string Username;
    private string Password;
    private string Role;
    private User_Manager user_Manager;

    public User()
    {
    }
    public User(string username,string pwd,string role)
    {
        this.Username = username;
        this.Password = pwd;
        this.Role = role;
    }

    public string getUsername()
    {
        return Username;
    }

    public string getPassword()
    {
        return Password;
    }

    public string getRole()
    {
        return Role;
    }

    public void setUsername(string username)
    {
        this.Username = username;
    }

    public void setPassword(string password)
    {
        this.Password = password;
    }

    public void setRole(string role)
    {
        this.Role = role;
    }
}