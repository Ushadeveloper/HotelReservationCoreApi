using Dapper;
using HotelReservation.Model;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace HotelReservation.Services
{
    public class GuestService : IGuestService
    {

        //All Data Display of Guest.................
        public async Task<List<Guest>> GetGuest()
        {
            var query = "SELECT * FROM Guest;";

            using (IDbConnection connection = new SqlConnection(DBconnection.dbConnectionString))
            {
                var result = await connection.QueryAsync<Guest>(query);
                return result.ToList();
            }
        }

        // Data Display of Guest by Id .................

        public async Task<Guest> GetGuest(int id)
        {
            var query = $"SELECT * FROM Guest where id={id};";
            using (IDbConnection connection = new SqlConnection(DBconnection.dbConnectionString))
            {
                var result = await connection.QueryAsync<Guest>(query);
                return result.FirstOrDefault();
            }
        }

        // Data Post of Guest by Id .................

        public async Task<int> PostGuest(Guest guest)
        {

            string date = Convert.ToString(guest.DOB);
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            var testDate=Convert.ToDateTime(date, ci.DateTimeFormat).ToString("MM/dd/yyyy");

            //string dob = Convert.ToString(guest.DOB);
            //var dtDob = DateTime.ParseExact(dob, "dd/mm/yyyy", CultureInfo.InvariantCulture);

            var query = $"insert into Guest ( Name, DOB, Email, Phone , Address ) " +
                $"values ('{guest.Name}',convert(date, '{testDate}'),'{guest.Email}','{guest.Phone}','{guest.Address}') ;";
            using (IDbConnection connection = new SqlConnection(DBconnection.dbConnectionString))
            {
                var result = await connection.ExecuteAsync(query);

                return result;
            }
        }



    }
}
