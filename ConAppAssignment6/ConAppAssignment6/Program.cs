
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConAppAssignment6
{

    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string constr = "server=LAPTOP-KP6PKP4L;database=Assignment6;trusted_connection=true;";
        private static object id;

        static void Main(string[] args)
        {

            string choice;
            do
            {
                Console.WriteLine("Choose Operation to perform");
                Console.WriteLine("1.select\n2.insert into Products table\n3.Update into Products table\n4.delete\n");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "select * from Products"
                                };
                                con.Open();
                                reader = cmd.ExecuteReader();
                                while (reader.Read())
                                {
                                    Console.WriteLine("Product ID: \t" + reader["ProductId"]);
                                    Console.WriteLine("Product Name: \t" + reader["ProductName"]);
                                    Console.WriteLine(" Price: \t" + reader["Price"]);
                                    Console.WriteLine("MfDate: \t" + reader["MfDate"]);
                                    Console.WriteLine("ExpDate: \t" + reader["ExpDate"]);
                                    Console.WriteLine("\n");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                        
                            break;
                        }
                    case 2:
                        {
                        try
                        {
                            con = new SqlConnection(constr);
                            cmd = new SqlCommand
                            {
                                Connection = con,
                                CommandText = "insert into Products(ProductId,ProductName,Price,Quantity,MfDate,ExpDate) values (@id,@name,@price,@quantity,@mfdate,@expdate)"
                            };
                            Console.WriteLine("Enter product Id");
                            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter ProductName ");
                            cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                            Console.WriteLine("Enter Product Price");
                            cmd.Parameters.AddWithValue("@price", float.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter Product Quantity");
                            cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter Product MfDate");
                            cmd.Parameters.AddWithValue("@mfdate", DateTime.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter Product ExpDate");
                            cmd.Parameters.AddWithValue("@expdate", DateTime.Parse(Console.ReadLine()));
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Record Inserted!!!");
                        }
                        catch (SqlException se)
                        {
                            Console.WriteLine("Error!!!" + se.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error!!!" + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                            Console.WriteLine("End odf a Program");
                            Console.ReadKey();
                        }
                        break;
                        }
                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "update Products set ProductName=@name,Price=@price , Quantity=@quantity,MfDate=@mfdate,ExpDate=@expdate  where ProductId=@id"
                                };
                                Console.WriteLine("Enter product Id");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                                Console.WriteLine("Enter ProductName ");
                                cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                                Console.WriteLine("Enter Product Price");
                                cmd.Parameters.AddWithValue("@price", float.Parse(Console.ReadLine()));
                                Console.WriteLine("Enter Product Quantity");
                                cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));
                                Console.WriteLine("Enter Product MfDate");
                                cmd.Parameters.AddWithValue("@mfdate", DateTime.Parse(Console.ReadLine()));
                                Console.WriteLine("Enter Product ExpDate");
                                cmd.Parameters.AddWithValue("@expdate", DateTime.Parse(Console.ReadLine()));

                                con.Open();
                                int noe = cmd.ExecuteNonQuery();

                                if (noe > 0)
                                {
                                    Console.WriteLine($"Record updated for Id {id} !!! ");
                                }
                                else
                                {
                                    Console.WriteLine($"No such Id {id}  exist in employee table to be updated");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("End odf a Program");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "delete from Products where ProductId=@id"
                                };
                                Console.WriteLine("Enter Product Id to delete the product");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine("Record deleted successfully");
                                }

                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("End odf a Program");
                                Console.ReadKey();
                            }
                            break;
                        }
                  

                }
                Console.WriteLine("Do you want to continue");
                choice = Console.ReadLine();
            } while (choice == "yes");
        }
    }
}







