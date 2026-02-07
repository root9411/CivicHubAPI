using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Interfaces
{
    public interface IEncryptionService
    {
        string EncryptData<T>(T data);
        T DecryptData<T>(string cipherText);
    }
}
