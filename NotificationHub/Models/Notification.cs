using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHub.Models
{
    public enum Type {
           URGENT, WARNING, INFO
    }

    public enum Scope {
          GLOBAL, GROUP, DEVICE
    }

  
    public class Notification
    {
        int _notId;
        public int NotId
        {
            get { return _notId; }
            set { _notId = value; }
        }
        Type _type;
        public Type Type {
            get { return _type;  }
            set { _type = value; }
        }
        String _message;
        public String Message {
            get { return _message; }
            set { _message = value; }
        }
        Scope _scope;
        public Scope Scope {
            get { return _scope; }
            set { _scope = value; }
        }
        DateTime _date;
        public DateTime Date {
            get { return _date; }
            set { _date = value; }
        }

        static int _j = 0;
        public int I
        {
            get { return _j; }
            set { _j = value; }
        }

        public Notification()
        {

        }

        public Notification(Type type, string message, Scope scope)
        {
            this.NotId = ++_j;
            this._type = type;
            this._message = message;
            this._scope = scope;
        }

     
    }
}
