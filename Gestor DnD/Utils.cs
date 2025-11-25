using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_DnD
{

    internal class Utils
    {
        public static string PastaDoPrograma(string nome)
        {
            string pastainicial = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            pastainicial += @"\" + nome;
            if (System.IO.Directory.Exists(pastainicial)==false)
                System.IO.Directory.CreateDirectory(pastainicial);
            return pastainicial;
        }
    }
}
