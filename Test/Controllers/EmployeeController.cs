using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet(Name = "getToken")]
        public IActionResult getToken()
        {
            var client = new RestClient("https://dev-sn6rjax0.us.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"Y6G15jEeIRZIV0KecQyzj7V3fIUz4zdr\",\"client_secret\":\"fBgbjsHxwtZWAHixbwiGNU3nkM9IbAY9HVk5_Hat6af0hKCaTt67BdbG5f2nosWV\",\"audience\":\"https://dev-sn6rjax0.us.auth0.com/api/v2/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            var response = client.Execute(request);
            return Ok(response.Content);
        }
        [AllowAnonymous]
        [HttpGet(Name = "getEmployeeList")]
        public IActionResult GetAll()
        {
            var list = _service.getEmployeeList();
            return Ok(list);
        }

        [AllowAnonymous]
        [HttpGet("{empId}", Name = "getEmployeeDetails")]
        public IActionResult Get(int empId)
        {
            var details = _service.getEmployeeDetails(empId);
            return Ok(details);
        }

        [Authorize]
        [HttpPost(Name = "addEmployee")]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid input!");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.addEmployee(employee);
            if (await _service.SaveChangesAsync())
            {
                return CreatedAtRoute(
                  "getEmployeeDetails",
                  new { empId = employee.EmployeeId },
                  employee);
            }
            else
                return NotFound("Something went wrong!!");
        }

        [Authorize]
        [HttpDelete("{empId}", Name = "deleteEmployee")]
        public async Task<IActionResult> Delete(int empId)
        {
            if (empId <= 0)
                return BadRequest("Not a valid empolyee id");

            _service.deleteEmployee(empId);

            if (await _service.SaveChangesAsync())
            {
                return Ok("Employee deleted successfully!!");
            }
            else
                return NotFound("Something went wrong!!");

        }
    }
}
