using System;
using System.Collections.Generic;
using System.Text;

namespace GottaHaveStandards
{

    public class ExecutionResult
    {
        public bool addCogResult(string key, object value)
        {
            if (cogResults.ContainsKey(key)) { // don't add a dup
                return false;

            } else {
                cogResults.Add(key, value);
                return true;
            }
        }

        public bool addCogException(string key, Exception value)
        {
            if (cogExceptions.ContainsKey(key)) { // don't add a dup
                return false;

            } else {
                cogExceptions.Add(key, value);
                return true;
            }
        }

        public Dictionary<string, object> cogResults { get; } = new Dictionary<string, object>();        // list maybe?
        
        // private Dictionary<string, object> _cogResults = new Dictionary<string, object>();        // list maybe?
        // public T cogResults<T>(string key) {
        //     return (T)_cogResults[key];
        // } 


        public Dictionary<string, Exception> cogExceptions { get; } = new Dictionary<string, Exception>(); // list maybe?

        public bool hadError {
            get {
                return (cogExceptions.Count > 0);
            }
        }
    }

    public class ExecutionResult<T> : ExecutionResult
    {
        public T results;
    }

}
