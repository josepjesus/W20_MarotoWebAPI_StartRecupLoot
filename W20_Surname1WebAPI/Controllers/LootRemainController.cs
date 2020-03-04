using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using W20_Surname1WebAPI.Models;

namespace W20_Surname1WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/LootRemain")]
    public class LootRemainController : ApiController
    {
        // GET api/LootRemain/GetLootRemain
        [HttpGet]
        public int GetLootRemain()
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = "SELECT points FROM dbo.LootRemaining";
                int points = cnn.Query<int>(sql).FirstOrDefault();
                return points;
            }
        }


        // POST api/LootRemain/ChangePoints
        [HttpPost]
        public IHttpActionResult ChangePoints(int points)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"UPDATE dbo.LootRemaining SET points = '{points}' WHERE id = 1";
                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error changing the Loot Remining: " + ex.Message);
                }

                return Ok();
            }
        }
    }
}
