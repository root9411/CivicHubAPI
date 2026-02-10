using SharedLibrary.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
public class EncryptionService : IEncryptionService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncryptionService()
    {
        _key = Encoding.UTF8.GetBytes("A9f3K2mP7R8X4L6Z0C1D5E9H2WQYBTJX");
        _iv = Encoding.UTF8.GetBytes("F7K9M2P4R8X3L6Z0");
    }

    public string EncryptData<T>(T data)
    {
        var json = JsonSerializer.Serialize(data);

        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using var sw = new StreamWriter(cs);

        sw.Write(json);
        sw.Flush();
        cs.FlushFinalBlock();

        return Convert.ToBase64String(ms.ToArray());
    }

    public T DecryptData<T>(string cipherText)
    {
        if (string.IsNullOrWhiteSpace(cipherText))
            throw new Exception("Empty encrypted payload");

        var bytes = Convert.FromBase64String(cipherText);

        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(bytes);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);

        var json = sr.ReadToEnd();
        return JsonSerializer.Deserialize<T>(json)!;
    }
}
