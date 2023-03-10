
using System.Data.SqlClient;

namespace ProductCrudNimapInfoteck.Models
{
    public class CategoryCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public CategoryCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Category> CatList()
        {
            List<Category> catlist = new List<Category>();
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category cat = new Category();
                    cat.CategoryId = Convert.ToInt32(dr["Categoryid"]);
                    cat.CategoryName = dr["categoryname"].ToString();
                    catlist.Add(cat);
                }
            }
            con.Close();
            return catlist;
        }
        public Category GetCatById(int id)
        {
            Category cat = new Category();
            string qry = "select * from category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cat.CategoryId = Convert.ToInt32(dr["categoryid"]);
                    cat.CategoryName = dr["categoryname"].ToString();
                }
            }
            con.Close();
            return cat;
        }
        public int AddCat(Category cat)
        {
            int result = 0;
            string qry = "insert into category values(@categoryname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryname", cat.CategoryName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCat(Category cat)
        {
            int result = 0;
            string qry = "update category set categoryname=@categoryname where categoryid=@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryname", cat.CategoryName);
            cmd.Parameters.AddWithValue("@categoryid", cat.CategoryId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCat(int id)
        {
            int result = 0;
            string qry = "delete from  category where categoryid=@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
