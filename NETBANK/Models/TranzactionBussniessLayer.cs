using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NETBANK.Models
{
    public class TranzactionBussniessLayer
    {
        public IEnumerable<Account> Accounts
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["AccountContext"].ConnectionString;

                List<Account> accounts = new List<Account>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AllAccounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Account account = new Account();
                        account.CardNumber = Convert.ToInt32(rdr["CardNumber"]);
                        account.Name = rdr["Name"].ToString();
                        account.CardType = rdr["CardType"].ToString();
                        account.Cash = Convert.ToInt32(rdr["Cash"]);
                        account.BankId = Convert.ToInt32(rdr["BankId"]);
                        accounts.Add(account);

                    }

                }

                return accounts;
            }
        }
             public void AddAccount(Account account)
        {
            string connectionString =
          ConfigurationManager.ConnectionStrings["AccountContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@CardNumber";
                paramId.Value = account.CardNumber;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = account.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@CardType";
                paramGender.Value = account.CardType;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@Cash";
                paramCity.Value = account.Cash;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@BankId";
                paramDateOfBirth.Value = account.BankId;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            }
    }
}