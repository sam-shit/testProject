using Microsoft.AspNetCore.Mvc;
using EmpMVC.Models;
using System.Data;
using System.Data.SqlClient;
namespace EmpMVC.Controllers;

public class ProductController : Controller {
    public IActionResult List() {
         string constr = "User ID=sa;password=examlyMssql@123; server=localhost;Database=testDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

         SqlConnection con = new SqlConnection(constr);
         SqlCommand command = new SqlCommand("select * from product", con);
         con.Open();
         SqlDataReader reader = command.ExecuteReader();
         DataTable prodTable = new DataTable();
         prodTable.Load(reader);
         return View(prodTable);
    }

    public IActionResult Create() {
        return View();
    }
    [HttpPost]

    public IActionResult Create(int id, string name, int price, int stock) {
        if (ModelState.IsValid) {
            string constr = "User ID=sa;password=examlyMssql@123; server=localhost;Database=testDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("AddProduct", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@stock", stock);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("List");
        }
        return View();
    }
}