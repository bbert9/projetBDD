using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetBDD
{
    public class client
    {
        int id_client;
        string prenom;
        string nom_contact;
        int id_fidelio;
        string ville;
        string province;
        int code_postal;
        int telephone;
        string courriel;
        public client(int id_client,string prenom,string nom_contact,int id_fidelio,string ville,string province, int code_postal,int telephone,string courriel)
        {
            this.id_client = id_client;
            this.prenom = prenom;
            this.nom_contact = nom_contact;
            this.id_fidelio = id_fidelio;
            this.ville = ville;
            this.province = province;
            this.code_postal = code_postal;
            this.telephone = telephone;
            this.courriel = courriel;
        }
        public void add(MySqlConnection maConnection)
        {
            MySqlCommand cmd2 = new MySqlCommand("insert into client values (" + this.id_client + "," + this.prenom + "," + this.nom_contact + "," + this.id_fidelio + "," + this.ville + "," + this.province + "," + this.code_postal +","+ this.telephone + "," + this.courriel+");", maConnection);
            cmd2.ExecuteNonQuery();
        }
        public void Suppression(MySqlConnection maConnexion, int id)
        {
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM client WHERE id_client =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_string(int id, string a_maj, int maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE client SET " + a_maj + " =" + "'" + maj + "'" + " WHERE id_client =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_int(int id, string a_maj, int maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE client SET " + a_maj + " =" + maj + " WHERE id_client =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
    }
}
