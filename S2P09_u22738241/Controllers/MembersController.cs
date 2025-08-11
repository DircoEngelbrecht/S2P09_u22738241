using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace S2P09_u22738241.Controllers
{
    public class MembersController : Controller
    {
        private SqlConnection myConnection = new SqlConnection(Global.ConnectionString);

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult DoInsert(string fullName, string clubName, int Age, decimal memberFee)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(
                    @"INSERT INTO dbo.ClubMembership (FullName, ClubName, Age, MembershipFee)
              VALUES (@FullName, @ClubName, @Age, @Fee);", myConnection);

                myCommand.Parameters.AddWithValue("@FullName", fullName);
                myCommand.Parameters.AddWithValue("@ClubName", clubName);
                myCommand.Parameters.AddWithValue("@Age", Age);
                myCommand.Parameters.AddWithValue("@Fee", memberFee);

                myConnection.Open();
                int rows = myCommand.ExecuteNonQuery();
                TempData["Msg"] = "Success: " + rows + " row(s) added.";
            }
            catch (Exception err)
            {
                TempData["Msg"] = "Error: " + err.Message;
            }
            finally
            {
                if (myConnection.State != System.Data.ConnectionState.Closed)
                    myConnection.Close();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DoUpdate(int id, string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                TempData["Msg"] = "Please provide a name.";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                SqlCommand myCommand = new SqlCommand(
                    @"UPDATE dbo.ClubMembership
                SET FullName = @FullName
              WHERE Id = @Id;", myConnection);

                myCommand.Parameters.AddWithValue("@Id", id);
                myCommand.Parameters.AddWithValue("@FullName", fullName);

                myConnection.Open();
                int rows = myCommand.ExecuteNonQuery();
                TempData["Msg"] = rows > 0
                    ? $"Success: member {id} name updated."
                    : "No rows updated (check Id).";
            }
            catch (Exception err)
            {
                TempData["Msg"] = "Error (Update): " + err.Message;
            }
            finally
            {
                if (myConnection.State != System.Data.ConnectionState.Closed)
                    myConnection.Close();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DoDelete(int id)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(
                    @"DELETE FROM dbo.ClubMembership WHERE Id=@Id;", myConnection);

                myCommand.Parameters.AddWithValue("@Id", id);

                myConnection.Open();
                int rows = myCommand.ExecuteNonQuery();
                TempData["Msg"] = rows > 0 ? $"Success: member {id} deleted." : "No rows deleted (check Id).";
            }
            catch (Exception err)
            {
                TempData["Msg"] = "Error: " + err.Message;
            }
            finally
            {
                if (myConnection.State != System.Data.ConnectionState.Closed)
                    myConnection.Close();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
