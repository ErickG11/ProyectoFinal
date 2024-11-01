﻿using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoFinal.Recursos {
    public class Utilidades {
        public static string EncriptarContraseña(string contraseña) {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(contraseña));

                foreach(byte b in result) 
                    sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
