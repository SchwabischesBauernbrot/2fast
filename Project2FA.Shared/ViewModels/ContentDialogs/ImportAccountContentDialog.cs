﻿
using Project2FA.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
#if WINDOWS_UWP
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
#endif

namespace Project2FA.ViewModels
{
    public class ImportAccountContentDialog : AddAccountViewModelBase
    {
        public ImportAccountContentDialog()
        {
            //BCrypt.Net.BCrypt.
        }

        //public static string Decrypt(string EncryptedText, byte[] key, byte[] iv)
        //{
        //    string sR = string.Empty;
        //    try
        //    {
        //        byte[] encryptedBytes = Convert.FromBase64String(EncryptedText);

        //        GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
        //        AeadParameters parameters =
        //                  new AeadParameters(new KeyParameter(key), 128, iv, null);
        //        //ParametersWithIV parameters = 
        //        //new ParametersWithIV(new KeyParameter(key), iv);

        //        cipher.Init(false, parameters);
        //        byte[] plainBytes =
        //               new byte[cipher.GetOutputSize(encryptedBytes.Length)];
        //        Int32 retLen = cipher.ProcessBytes
        //              (encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
        //        cipher.DoFinal(plainBytes, retLen);

        //        sR = Encoding.UTF8.GetString(plainBytes).TrimEnd
        //              ("\r\n\0".ToCharArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine(ex.StackTrace);
        //    }

        //    return sR;
        //}

    }
}
