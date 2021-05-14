using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetBDD
{
    public class velo
    {
        public int id_velo;
        int id_modele;
        string nom;
        string grandeur;
        string ligne;
        int prix;
        public velo(int id_v, int id_m, string nom, string grandeur, string ligne, int prix, MySqlConnection maConnection)
        {
            this.id_modele = id_m;
            this.id_velo = id_v;
            this.nom = nom;
            this.grandeur = grandeur;
            this.ligne = ligne;
            this.prix = prix;
            
            
        }
        public void add(MySqlConnection maConnection)
        {
            MySqlCommand cmd2 = new MySqlCommand("insert into velo values (" + this.id_velo + "," + this.id_modele + "," + "'" + this.nom + "'" + "," + "'" + this.grandeur + "'" + "," + "'" + this.ligne + "'" + "," + this.prix + ");", maConnection);
            cmd2.ExecuteNonQuery();
        }
        public void Suppression(MySqlConnection maConnexion, int id)
        {
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM velo WHERE id_velo ="+id+";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_string(int id,string a_maj, string maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE velo SET "+a_maj+" ="+"'"+maj+"'"+" WHERE id_velo ="+id+";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_int(int id, string a_maj, int maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE velo SET " + a_maj + " ="  + maj + " WHERE id_velo =" + id+";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void stock(MySqlConnection maConnexion)
        {
            Console.WriteLine("hey1");
            MySqlCommand cmd2 = new MySqlCommand("select * from piece;", maConnexion);
            MySqlDataReader reader = cmd2.ExecuteReader();
            Console.WriteLine(reader.FieldCount);
            
          
            while(reader.Read())
            {
                Console.WriteLine(reader.GetValue(0).ToString()); // ne marche pas 
                Console.WriteLine("hey");

            }
            for (int i = 0; i < 99999999999; i++)
            {

            }
        }
    }
}
