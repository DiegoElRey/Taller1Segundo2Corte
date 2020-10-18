namespace parcial1Angular.Controllers {
    using BLL;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route ("api/[controller]")]
    [ApiController]
    public class TotalAyudas : ControllerBase {
        private readonly PersonaService _personaService;

        public IConfiguration Configuration { get; }

        public TotalAyudas(IConfiguration configuration) {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService (connectionString);
        }

        //GET: Api/TotalAyudas
        [HttpGet]
        public ActionResult<decimal> GetTotalAyudas () {
            var response = _personaService.Total ();
            return Ok (response);

        }
    }

}