using Microsoft.AspNetCore.Mvc;
using MyCMS.Data.TestData;

namespace MyCMS.Web.API
{
    /// <summary>
    /// Controller for test only purpose.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        TestDataImporter _testImporter;

        /// <summary>
        /// Controller for test only purpose.
        /// </summary>
        /// <param name="testImporter"></param>
        /// <returns></returns>
        public TestController(TestDataImporter testImporter)
        {
            _testImporter = testImporter;
        }

        /// <summary>
        /// Empty current database and load test data.
        /// </summary>
        [HttpPost]
        public IActionResult ImportTestData()
        {
            string status = "OK";
            string message = null;

            try
            {
                _testImporter.Import();
            }
            catch (Exception ex)
            {
                status = "ERROR";
                message = ex.Message;
            }

            return Ok(new { status = status, message = message });
        }
    }
}
