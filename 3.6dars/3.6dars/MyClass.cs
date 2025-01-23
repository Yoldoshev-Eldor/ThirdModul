using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._6dars;

public class MyClass
{
    private static MyClass _instance;
    private MyClass()
    {
       

    }
    public static MyClass GetInstance()
    {
        if (_instance == null)
        {
            _instance = new MyClass();
        }
        return _instance;
    }
}
