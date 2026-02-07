using SharedLibrary.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class EncryptionService : IEncryptionService
{
    private readonly string _secretKey;
    private readonly string _iv;

    public EncryptionService()
    {
        // MUST be same as Angular
        _secretKey = "A9f3K2mP7R8X4L6Z0C1D5E9H2WQYBTJX";
        _iv = "F7K9M2P4R8X3L6Z0"; 
    }

    public string EncryptData<T>(T data)
    {
        try
        {
            var jsonString = JsonSerializer.Serialize(data);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_secretKey);
            aes.IV = Encoding.UTF8.GetBytes(_iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);

            sw.Write(jsonString);
            sw.Flush();
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw new Exception("Encryption failed", ex);
        }
    }

    public T DecryptData<T>(string cipherText)
    {
        try
        {
            var cipherBytes = Convert.FromBase64String(cipherText);

            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_secretKey);
            aes.IV = Encoding.UTF8.GetBytes(_iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            var decryptedJson = sr.ReadToEnd();
            return JsonSerializer.Deserialize<T>(decryptedJson)!;
        }
        catch (Exception ex)
        {
            throw new Exception("Decryption failed", ex);
        }
    }
}
