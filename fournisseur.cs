using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace projetBDD
{
    public class fournisseur
    {
        int num_siret;
        string nom;
        string ville;
        string province;
        int code_postal;
        int telephone;
        string courriel;
        public fournisseur(int num_siret,string nom,string ville,string province,int code_postal,int telephone,string courriel)
        {
            this.num_siret = num_siret;
            this.nom = nom;
            this.ville = ville;
            this.province = province;
            this.code_postal = code_postal;
            this.telephone = telephone;
            this.courriel = courriel;
        }
        public void add(MySqlConnection maConnection)
        {
            MySqlCommand cmd2 = new MySqlCommand("insert into fournisseur values (" + this.num_siret + "," + this.nom + "," + this.ville  + ","  + this.province  + "," + this.code_postal + "," + this.telephone + "," + this.courriel+");", maConnection);
            cmd2.ExecuteNonQuery();
        }
        public void Suppression(MySqlConnection maConnexion, int id)
        {
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM fournisseur WHERE num_siret =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_string(int id, string a_maj, int maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE fournisseur SET " + a_maj + " =" + "'" + maj + "'" + " WHERE num_siret =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
        public void maj_int(int id, string a_maj, int maj, MySqlConnection maConnexion)
        {
            MySqlCommand cmd2 = new MySqlCommand("UPDATE fournisseur SET " + a_maj + " =" + maj + " WHERE num_siret =" + id + ";", maConnexion);
            cmd2.ExecuteNonQuery();
        }
    }
}
