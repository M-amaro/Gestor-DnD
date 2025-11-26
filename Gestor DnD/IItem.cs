using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_DnD
{
    /// <summary>
    /// Interface para classes Leitor, Livro e empréstimo
    /// </summary>
    internal interface IItem
    {
        //Adicionar
        void Adicionar();
        //Atualizar 
        void Atualizar();
        //Apagar
        void Apagar();
    }
}
