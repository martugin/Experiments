using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace e0169
{
    public static class Encryption
    {
        //public static string Encrypt(string lineToConvert, string key)
        //{
        //    try
        //    {
        //        Rijndael RijndaelAlg = Rijndael.Create();

        //        string newLine = RijndaelAlg.CreateEncryptor(key.)

        //        // Encrypt text to a file using the file name, key, and IV.
        //        EncryptTextToFile(sData, FileName, RijndaelAlg.Key, RijndaelAlg.IV);

        //        // Decrypt the text from a file using the file name, key, and IV.
        //        string Final = DecryptTextFromFile(FileName, RijndaelAlg.Key, RijndaelAlg.IV);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //public static void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
        //{
        //    try
        //    {
        //        // Create a new Rijndael object.
        //        Rijndael RijndaelAlg = Rijndael.Create();

        //        // Create a CryptoStream using the FileStream 
        //        // and the passed key and initialization vector (IV).
        //        CryptoStream cStream = new CryptoStream(fStream,
        //            RijndaelAlg.CreateEncryptor(Key, IV),
        //            CryptoStreamMode.Write);

        //        // Create a StreamWriter using the CryptoStream.
        //        StreamWriter sWriter = new StreamWriter(cStream);

        //        try
        //        {
        //            // Write the data to the stream 
        //            // to encrypt it.
        //            sWriter.WriteLine(Data);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occurred: {0}", e.Message);
        //        }
        //        finally
        //        {
        //            // Close the streams and
        //            // close the file.
        //            sWriter.Close();
        //            cStream.Close();
        //            fStream.Close();
        //        }
        //    }
        //    catch (CryptographicException e)
        //    {
        //        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        //    }
        //    catch (UnauthorizedAccessException e)
        //    {
        //        Console.WriteLine("A file error occurred: {0}", e.Message);
        //    }

        //}

        //public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
        //{
        //    try
        //    {
        //        // Create or open the specified file. 
        //        FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

        //        // Create a new Rijndael object.
        //        Rijndael RijndaelAlg = Rijndael.Create();

        //        // Create a CryptoStream using the FileStream 
        //        // and the passed key and initialization vector (IV).
        //        CryptoStream cStream = new CryptoStream(fStream,
        //            RijndaelAlg.CreateDecryptor(Key, IV),
        //            CryptoStreamMode.Read);

        //        // Create a StreamReader using the CryptoStream.
        //        StreamReader sReader = new StreamReader(cStream);

        //        string val = null;

        //        try
        //        {
        //            // Read the data from the stream 
        //            // to decrypt it.
        //            val = sReader.ReadLine();


        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occurred: {0}", e.Message);
        //        }
        //        finally
        //        {

        //            // Close the streams and
        //            // close the file.
        //            sReader.Close();
        //            cStream.Close();
        //            fStream.Close();
        //        }

        //        // Return the string. 
        //        return val;
        //    }
        //    catch (CryptographicException e)
        //    {
        //        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        //        return null;
        //    }
        //    catch (UnauthorizedAccessException e)
        //    {
        //        Console.WriteLine("A file error occurred: {0}", e.Message);
        //        return null;
        //    }
        //}
    }
}
