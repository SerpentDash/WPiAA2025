using System;

namespace Singleton
{
    public class Vault
    {
        private static Vault? _instance;
        private static readonly object _lock = new object();
        private string? _key;
        private bool _keyRetrieved = false;

        private Vault()
        {
            // Generowanie klucza przy tworzeniu instancji
            _key = Guid.NewGuid().ToString();
        }

        public static Vault Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Vault();
                    }
                    return _instance;
                }
            }
        }

        public string? GetKey()
        {
            if (!_keyRetrieved)
            {
                _keyRetrieved = true;
                return _key;
            }
            return null; // Klucz już został pobrany
        }
    }
}
