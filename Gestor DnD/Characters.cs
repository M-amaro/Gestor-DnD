using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gestor_DnD
{
    internal class Characters : IItem
    {
        public int character_id { get; set; }
        public string name_player { get; set; }
        public string name_char { get; set; }
        public string class_char {  get; set; }
        public string race_char { get; set; }
        public int level_char { get; set; }
        public int gold {  get; set; }
        BaseDados bd;
        public Characters(BaseDados bd) { this.bd = bd; }
        public void Adicionar()
        {
            string sql = @"INSERT INTO Characters(name_player,name_char,class_char,race_char,level_char,gold) VALUES 
                        (@name_player,@name_char,@class_char,@race_char,@level_char,@gold)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@name_player",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.name_player
                },
                new SqlParameter()
                {
                    ParameterName="@name_char",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.name_char
                },
                new SqlParameter()
                {
                    ParameterName="@class_char",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.class_char
                },
                new SqlParameter()
                {
                    ParameterName="@race_char",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.race_char
                },
                new SqlParameter()
                {
                    ParameterName="@level_char",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.level_char
                },
                new SqlParameter()
                {
                    ParameterName="@gold",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.gold
                },
            };
            bd.ExecutarSQL(sql, parametros);
        }
        public void Apagar()
        {
            string sql = "DELETE FROM Characters WHERE character_id=" + character_id;
            bd.ExecutarSQL(sql);
        }
        public void Atualizar()
        {
            string sql = @"UPDATE Characters SET name_player=@name_player,name_char=@name_char,
                            class_char=@class_char,race_char=@race_char,level_char=@level_char,
                            gold=@gold WHERE character_id=@character_id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@name_player",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.name_player
                },
                new SqlParameter()
                {
                    ParameterName="@name_char",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.name_char
                },
                new SqlParameter()
                {
                    ParameterName="@class_char",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.class_char
                },
                new SqlParameter()
                {
                    ParameterName="@race_char",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.race_char
                },
                new SqlParameter()
                {
                    ParameterName="@level_char",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.level_char
                },
                new SqlParameter()
                {
                    ParameterName="@gold",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.gold
                }
            };
            bd.ExecutarSQL(sql, parametros);
        }
        public DataTable Listar()
        {
            return bd.DevolveSQL("SELECT name_player,name_char,class_char, race_char, level_char, gold FROM Characters ORDER BY name_player");
        }
        public void Procurar()
        {
            string sql = "SELECT * FROM Characters WHERE character_id=" + character_id;
            DataTable temp = bd.DevolveSQL(sql);
            if (temp != null && temp.Rows.Count > 0)
            {
                DataRow linha = temp.Rows[0];
                this.name_player = linha["name_player"].ToString();
                this.name_char = linha["name_char"].ToString();
                this.class_char = linha["class_char"].ToString();
                this.race_char = linha["race_char"].ToString();
                this.level_char = int.Parse(linha["level_char"].ToString());
                this.gold = int.Parse(linha["gold"].ToString());
            }
        }
    }

}
