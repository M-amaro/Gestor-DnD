using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Gestor_DnD
{
    public class BaseDados
    {
        string strligacao;
        string NomeBD;
        string CaminhoBD;
        SqlConnection ligacaoSQL;

        public BaseDados(string NomeBD)
        {
            this.NomeBD = NomeBD;
            strligacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            //Verificar a pasta do projeto
            CaminhoBD = Utils.PastaDoPrograma("Gestao_DnD");
            CaminhoBD += @"\" + NomeBD + ".mdf";
            //Verificar se a bd existe
            if (System.IO.File.Exists(CaminhoBD) == false)
            {
                //se não existir
                //criar a bd
                CriarBD();
            }
            //ligação à bd
            ligacaoSQL = new SqlConnection(strligacao);
            ligacaoSQL.Open();
            ligacaoSQL.ChangeDatabase(this.NomeBD);
        }
        ~BaseDados(){}
        void CriarBD()
        {
            ligacaoSQL = new SqlConnection(strligacao);
            ligacaoSQL.Open();
            string sql = $@"
                        IF EXISTS(SELECT * FROM master.sys.databases
                                    WHERE name='{this.NomeBD}')
                          BEGIN
                                USE [master];
                                EXEC sp_detach_db {this.NomeBD};
                          END
                        ";

            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            comando.ExecuteNonQuery();
            sql = $"CREATE DATABASE {this.NomeBD} ON PRIMARY (NAME={this.NomeBD},FILENAME='{this.CaminhoBD}')";
            comando = new SqlCommand(sql, ligacaoSQL);
            comando.ExecuteNonQuery();
            ligacaoSQL.ChangeDatabase(this.NomeBD);
            //criar tabelas
            sql = @"CREATE TABLE Characters(
                    character_id int identity primary key,
                    name_player varchar(25),
                    name_char varchar(50) not null,
                    class_char varchar(15) not null,
                    race_char varchar(15) not null,
                    level_char int not null default 1, 
                    max_hp int default     ,
                    gold int default 0,
                    );
                    create table Items (
                    item_id int identity primary key,
                    item_name varchar(50) not null,
                    item_type varchar(20) not null,
                    df_bonus int default 0,           
                    dmg_bonus int defualt 0,                  
                    );
                    create table GearSlots (
                    slot_id int identity primary key,
                    character_id int references Characters(character_id),
                    slot_type varchar(20) not null,
                    item_id int references Items(item_id)
                    );";
            comando = new SqlCommand(sql, ligacaoSQL);
            comando.ExecuteNonQuery();
            comando.Dispose();
        }
        public void ExecutarSQL(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            if (parametros != null)
                comando.Parameters.AddRange(parametros.ToArray());
            comando.ExecuteNonQuery();
            comando.Dispose();
        }
        public DataTable DevolveSQL(string sql, List<SqlParameter> parametros = null)
        {
            DataTable dados = new DataTable();
            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            if (parametros != null)
                comando.Parameters.AddRange(parametros.ToArray());
            SqlDataReader registos = comando.ExecuteReader();
            dados.Load(registos);
            registos.Close();
            comando.Dispose();
            return dados;
        }
    }
}
