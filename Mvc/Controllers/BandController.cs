using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    [Produces("application/json")]
    [Route("api/Band")]
    public class BandController : Controller
    {
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyBandName(string bandName)
        {
            if (string.IsNullOrWhiteSpace(bandName)) return BadRequest();

            int bandsMatching = 0;

            string connectionString = @"Server=.,5433;Database=Mvc6RecipesSharedDb;User ID=sa;Password=P@ssw0rd";
            using (SqlConnection connection = new(connectionString))
            {
                string sql = @"SELECT COUNT(*) FROM [dbo].[Band] WHERE LOWER(@bandName)=LOWER(BandName)";
                connection.Open();
                using (SqlCommand cmd = new(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@bandName", bandName.Trim());
                    var result = cmd.ExecuteScalar();
                    if (result != null) bandsMatching = (int)result;
                }
            }

            return bandsMatching > 0 ? Json(data: $"Band name {bandName} is already in use.") : Json(data: true);
        }
    }
}
