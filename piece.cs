using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetBDD
{
    class piece
    {
        int id_produit;
        string description;
        int id_fournisseur;
        int prix;
        DateTime date_intro;
        DateTime date_disc;
        int delai;
        public piece(int id_produit, string description, int id_fournisseur, int prix, DateTime date_intro, DateTime date_disc, int delai, MySqlConnection maConnection)
        {
            this.id_produit = id_produit;
            this.date_intro = date_intro;
            this.date_disc = date_disc;
            this.id_fournisseur = id_fournisseur;
            this.prix = prix;
            this.delai = delai;
        }
        public void add(MySqlConnection maConnection)
        {
            MySqlCommand cmd2 = new MySqlCommand("insert into piece values (" + this.id_produit + "," + "'" + this.date_intro + "'" + "," + "'" + this.date_disc + "'" +","+id_fournisseur+","+prix+","+delai +");", maConnection);
            cmd2.ExecuteNonQuery();
        }
        public void Suppression(MySqlConnection maConnexion, int id)
        {
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM piece WHERE id_produit =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void stock(MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("select * from piece;", maConnexion);
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())

            {

                Console.WriteLine(reader.GetValue(0));

            }
        }
    }
}
