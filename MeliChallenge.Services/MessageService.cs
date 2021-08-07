using MeliChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeliChallenge.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage(string[] mensaje1, string[] mensaje2, string[] mensaje3)
        {

            string[] stringFinal = new string[5];
            string[] resultado = new string[5];

            for (int i = 0; i < mensaje1.Count(); i++)
            {

                var palabra1 = mensaje1[i];
                var palabra2 = mensaje2[i];
                var palabraValida = string.Empty;

                if (palabra1 != palabra2)
                {
                    if (palabra1 != string.Empty && palabra2 == string.Empty)
                    {
                        palabraValida = palabra1;
                    }
                    if (palabra1 == string.Empty && palabra2 != string.Empty)
                    {
                        palabraValida = palabra2;
                    }
                }
                else
                {
                    palabraValida = palabra1;
                }
                stringFinal[i] = palabraValida;
            }

            for (int i = 0; i < stringFinal.Count(); i++)
            {
                var palabra1 = stringFinal[i];
                var palabra2 = mensaje3[i];
                var palabraValida = string.Empty;

                if (palabra1 != palabra2)
                {
                    if (palabra1 != string.Empty && palabra2 == string.Empty)
                    {
                        palabraValida = palabra1;
                    }
                    if (palabra1 == string.Empty && palabra2 != string.Empty)
                    {
                        palabraValida = palabra2;
                    }
                }
                else
                {
                    palabraValida = palabra1;
                }
                resultado[i] = palabraValida;
            }
            return string.Join(" ", resultado);
           
        }
    }
}
