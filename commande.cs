using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace projetBDD
{
    public class commande
    {
        int id_commande;
        DateTime date;
        int id_adresse;
        DateTime date_livr;
        int quantite;
        int id_client;
        public commande(int id_commande, DateTime date, int id_adresse, DateTime date_livr, int quantite, int id_client)
        {
            this.id_adresse = id_adresse;
            this.id_commande = id_commande;
            this.date = date;
            this.date_livr = date_livr;
            this.quantite = quantite;
            this.id_client = id_client;
        }
        public void add(MySqlConnection maConnection)
        {
            MySqlCommand cmd2 = new MySqlCommand("insert into commande values (" + this.id_adresse + "," +this.id_commande+","+ "'" + this.date + "'" + "," + "'" + this.date_livr + "'" + "," + this.quantite + "," + this.id_client + ");", maConnection);
            cmd2.ExecuteNonQuery();
        }
        public void Suppression(MySqlConnection maConnexion, int id)
        {
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM commande WHERE id_commande =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_string(int id, string a_maj, string maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE commande SET " + a_maj + " =" + "'" + maj + "'" + " WHERE id_commande =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_int(int id, string a_maj, int maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE commande SET " + a_maj + " =" + maj + " WHERE id_commande =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
    }
}
