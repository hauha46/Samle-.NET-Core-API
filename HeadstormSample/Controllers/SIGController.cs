using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HeadstormSample.BusinessLogic;
using HeadstormSample.Model;

namespace HeadstormSample.Controllers
{
    [Route("api/SIG")]
    [ApiController]
    public class SIGController : ControllerBase
    {

        private ISIGBusiness _sIGBusiness;
        public SIGController(ISIGBusiness sIGBusiness)
        {
            this._sIGBusiness = sIGBusiness;
        }
        /// <summary>
        /// Add a new SIG into the database
        /// </summary>
        /// <param name="sig"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddSIG(SIG sig)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Input");
            SIG response = await this._sIGBusiness.AddSIG(sig);
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        /// <summary>
        /// Get a SIG with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SIG>> GetSIGById(int id)
        {
            SIG response = await this._sIGBusiness.GetSIGById(id);
            return Ok(response);
        }

        /// <summary>
        /// Get all available SIG in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<SIG>>> GetAllSIG()
        {
            var response = await this._sIGBusiness.GetAllSIG();
            return Ok(response);
        }

        /// <summary>
        /// Update a SIG with matching Id
        /// </summary>
        /// <param name="sig"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateSIG(SIG sig)
        {
            SIG check = await this._sIGBusiness.GetSIGById(sig.Id);
            if (check == null) return BadRequest("Invalid Input");
            SIG response = await this._sIGBusiness.UpdateSIG(sig);
            return Ok(response);
        }

        /// <summary>
        /// Remove a SIG from the database
        /// </summary>
        /// <param name="sig"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> RemoveSIG(SIG sig)
        {
            SIG check = await this._sIGBusiness.GetSIGById(sig.Id);
            if (check == null) return BadRequest("Invalid Input");
            SIG reponse = await this._sIGBusiness.RemoveSIG(sig);
            return Ok(reponse);
        }
    }
}
