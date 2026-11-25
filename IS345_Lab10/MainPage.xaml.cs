using Microsoft.Data.SqlClient;

namespace IS345_Lab10;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        if (Preferences.ContainsKey("Name"))
        {
            Navigation.PushAsync(new Page1());
        }
    }

    private void Button_Clicked(object sender, EventArgs e) // login button
    {
        SqlConnection con = new SqlConnection("Data Source=10.0.2.2,1433; Initial Catalog=Lab10DB;Persist Security Info = True;TrustServerCertificate=true; User ID = lab10user; Password = Lab10_HPB9z6n8J0#9");
        String sql;
        sql = "SELECT * FROM usertable where username = '" + txt1.Text + "'  and userpass = '" + txt2.Text + "' ";
        SqlCommand comm = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader reader = comm.ExecuteReader();
        if (reader.Read())
        {
            Preferences.Set("Name", txt1.Text);
            Preferences.Set("Pass", txt2.Text);
            Navigation.PushAsync(new Page1());
        }
        else
            DisplayAlert("Alert", "Wrong username or password", "OK");
        reader.Close();
        con.Close();
    }

    private void Register_Clicked(object sender, EventArgs e) // register button
    {
        if (string.IsNullOrWhiteSpace(txt1.Text) || string.IsNullOrWhiteSpace(txt2.Text))
        {
            DisplayAlert("Alert", "Please enter a username and password", "OK");
            return;
        }
        SqlConnection con = new SqlConnection("Data Source=10.0.2.2,1433; Initial Catalog=Lab10DB;Persist Security Info = True;TrustServerCertificate=true; User ID = lab10user; Password = Lab10_HPB9z6n8J0#9");
        String sql;
        sql = "SELECT * FROM usertable where username = '" + txt1.Text + "' ";
        SqlCommand comm = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader reader = comm.ExecuteReader();
        bool exists = reader.Read();
        reader.Close();
        if (exists)
        {
            con.Close();
            DisplayAlert("Alert", "This username already exists", "OK");
            return;
        }
        sql = "insert into usertable (username, userpass) values ('" + txt1.Text + "' , '" + txt2.Text + "')";
        comm = new SqlCommand(sql, con);
        comm.ExecuteNonQuery();
        con.Close();
        Preferences.Set("Name", txt1.Text);
        Preferences.Set("Pass", txt2.Text);
        DisplayAlert("Alert", "Account created successfully", "OK");
        Navigation.PushAsync(new Page1());
    }
}
