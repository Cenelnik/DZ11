using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ11
{
    /// <summary>
    /// Реализация словаря
    /// </summary>
    internal class OtusDictionary
    {
        /// <summary>
        /// По условию задания начальный размер = 32. 
        /// </summary>
        private string[] _arr = new string[32];
        private OtusDictionaryLogger? _otusDictionaryLogger;

        public bool Debug = true;
        public OtusDictionary (bool debug, OtusDictionaryLogger logger)
        {
            Debug = debug;
            _otusDictionaryLogger = logger;
        }

        public OtusDictionary(OtusDictionaryLogger logger)
        {
            _otusDictionaryLogger = logger;
        }

        public OtusDictionary()
        {
        }

        public delegate void OtusDictionaryLogger (string s);

        /// <summary>
        /// Метод для добавления элемента. 
        /// Value != null
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(int key, string value)
        {
            if (value == null) throw new ArgumentNullException($"{this.ToString()}: value is null");
            int index = key% _arr.Length;
            if (Debug) _otusDictionaryLogger?.Invoke($"{this.ToString()}: key% _arr.Length = {key}% {_arr.Length} = {index}");
            if (_arr[index] == null)
            {
                if (Debug) _otusDictionaryLogger?.Invoke($"{this.ToString()}: add new value.");
                _arr[index] = value;
            }else
            {
                if (Debug) _otusDictionaryLogger?.Invoke($"{this.ToString()}: collision! Create new array.");
                CreateNewArray();
                Add(key, value);
            }
        }

        private void CreateNewArray()
        {
            if (Debug) _otusDictionaryLogger?.Invoke($"{this.ToString()}: Creating new array with Length = {_arr.Length * 2}.");
            string[] newArr = new string[_arr.Length * 2];
            for(int i = 0; i < _arr.Length; i++)
            {
                if (Debug && _arr[i] != null) _otusDictionaryLogger?.Invoke($"{this.ToString()}: move {_arr[i]} to new array[{i}].");
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }

        /// <summary>
        /// Метод для получения значения из словаря
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal string Get(int key)
        {
            return _arr[key % _arr.Length];
        }
    }
}
