using Microsoft.AspNetCore.Mvc;
using MoominsApi.Repo;

namespace Moomins.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoominsController : ControllerBase
    {

        private static MoominsRepository moominsRepository = new MoominsRepository();



        //*********************** GET-pyynt�
        [HttpGet]
        [Route("api/MoominValley")]
        public List<Moomin> Moomins([FromQuery] string? query)
        {

            var moomins = moominsRepository.GetAllMoomins();

            if (string.IsNullOrEmpty(query))
            {
                return moomins;
            }
            else
            {
                var selectedMoomins = new List<Moomin>();

                foreach (var moomin in moomins)
                {
                    if (moomin.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedMoomins.Add(moomin);
                    }
                }

                return selectedMoomins;

            }
        }

        //*********************** GET-pyynt� yksi muumi by Id 
        [HttpGet]
        [Route("api/MoominValley/moomin/{id}")]
        public ActionResult<Moomin> Moomin(int id)
        {

            var moomins = moominsRepository.GetMoomin();

            foreach (var moomin in moomins)
            {
                if (moomin.Id == id)
                {
                    return Ok(moomin);
                }
            }

            return NotFound();

        }

        //*********************** POST-pyynt� lis�� uusi muumi

        [HttpPost]
        [Route("api/MoominValley/")]
        public ActionResult AddMoomin(Moomin moomin)
        {

            moominsRepository.AddMoomin(moomin);

            return Ok(moomin);

        }

        //*********************** PUT-pyynt� p�ivit� muumi
        [HttpPut]
        [Route("api/MoominValley/moomin/{id}")]
        public ActionResult UpdateMoomin(Moomin moomin)
        {
            moominsRepository.UpdateMoomin(moomin);

            return Ok();
        }

        //*********************** DELETE-pyynt� poista muumi

        [HttpDelete]
        [Route("api/MoominValley/moomin/{id}")]
        public ActionResult DeleteMoomin(Moomin moomin)
        {
            var result = moominsRepository.DeleteMoomin(moomin);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //*********************** GET-pyynt� perus tervehdys query parametrille nimi
        [HttpGet]
        [Route("MoiMuumi")]
        public string Terve([FromQuery] string? x)
        {
            return "Moi muumi:" + x;
        }


    }
}
