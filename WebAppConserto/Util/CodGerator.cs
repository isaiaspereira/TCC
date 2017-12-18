using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSmille_Ui.Util
{
    public class CodGerator
    {
        public static string GetCodigo()
        {
            int Tamanho = 22;
            string Senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();

                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());
                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();

                    if (!Senha.Contains(_char))
                        Senha += (_char);
                    else
                        i--;
                }
                else
                    i--;
            }
            return Senha;
        }
    }
}