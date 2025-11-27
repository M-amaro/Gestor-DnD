using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_DnD
{
    public partial class F_principal : Form
    {
        BaseDados bd;
        int character_id = 0;
        public F_principal(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }

        private void ListarChar()
        {
            CharacterDG.AllowUserToAddRows=false;
            CharacterDG.ReadOnly = true;
            CharacterDG.AllowUserToDeleteRows = false;
            CharacterDG.MultiSelect = false;
            CharacterDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Characters c = new Characters(bd);
            CharacterDG.DataSource = c.Listar();
        }

        private void F_principal_Load(object sender, EventArgs e)
        {
            ListarChar();
        }

        private void CharacterDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha=CharacterDG.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            character_id = int.Parse(CharacterDG.Rows[linha].Cells[0].Value.ToString());

            Characters c=new Characters(bd);
            c.character_id= character_id;
            c.Procurar();







        }























        private void CharacterDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
