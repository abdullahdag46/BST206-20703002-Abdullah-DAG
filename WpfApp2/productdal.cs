using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp2
{
    public class productdal
    {
        SqlConnection _connection=new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=musteri;Integrated Security=True;");

        public List<product> UrunleriGetir()
        {
            baglantıkontrol();
            SqlCommand command = new SqlCommand("select  *  from products " , _connection);
           SqlDataReader reader= command.ExecuteReader();
            List<product> products = new List<product>();
            while (reader.Read())
            {
                product product = new product()
                {
                    Id=(int)reader[0],
                    Name=reader[1].ToString(),
                    Fiyat= Convert.ToDecimal(reader[2]),
                    Stok= Convert.ToInt32(reader[3])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;
        }
        public void Ekle(product product)
        {
            baglantıkontrol();
            SqlCommand command = new SqlCommand("insert into products values @name,@fiyat@stok)",_connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@fiyat",product.Fiyat);
            command.Parameters.AddWithValue("@stok", product.Stok);
            command.ExecuteNonQuery();
            _connection.Close();

        }
        public void Güncelle(product product)
        {
            baglantıkontrol();
            SqlCommand command = new SqlCommand("Update Products set Namw=@name,Fiyat=@fiyat,Stok=@stok where Id=@id)", _connection);
            command.Parameters.AddWithValue("@id",product);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@fiyat", product.Fiyat);
            command.Parameters.AddWithValue("@stok", product.Stok);
            command.ExecuteNonQuery();
            _connection.Close();

        }
        private void baglantıkontrol()
        {
            if (_connection.State==ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
